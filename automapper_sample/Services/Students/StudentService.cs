using AutoMapper;
using automapper_sample.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automapper_sample.Services.Students
{
    public class StudentService : IStudentService
    {
        protected readonly MasterDbContext Context;
        private readonly IMapper _mapper;

        public StudentService(MasterDbContext masterDb,IMapper mapper )
        {
            this.Context = masterDb;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> CreateStudent(Student student)
        {
            this.Context.students.Add(student);
            this.Context.SaveChanges();
            IEnumerable<Student> students = new List<Student>();
            IEnumerable<Address> address = new List<Address>();

            students = await this.Context.students.ToListAsync();
            address = await this.Context.addresses.ToListAsync();
            foreach (var item in students)
            {
                item.Address = address.FirstOrDefault();
            }
            return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
        }

        public async  Task<IEnumerable<StudentDTO>> GetStudent()
        {
            IEnumerable<Student> students = new List<Student>();
            IEnumerable<Address >address = new List<Address>();
            StudentDTO dTO = null;
            IList<StudentDTO> studentdtos = new List<StudentDTO>();

            students = await this.Context.students.ToListAsync();
            address = await this.Context.addresses.ToListAsync();
           
            foreach (var item in students)
            {
                dTO = _mapper.Map<Student, StudentDTO>(item);

                Address address1 = address.Where(s => s.StudentID == item.StudentID).FirstOrDefault();
                //dTO1 = _mapper.Map<Address, AddressDTO>(address1);

                dTO.Address = address1;
                studentdtos.Add(dTO);
            }
            return studentdtos;

        }
    }
}
