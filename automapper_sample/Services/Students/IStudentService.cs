using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using automapper_sample.Model;
namespace automapper_sample.Services.Students
{
  public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetStudent();
        Task<IEnumerable<StudentDTO>> CreateStudent(Student student);

    }
}
