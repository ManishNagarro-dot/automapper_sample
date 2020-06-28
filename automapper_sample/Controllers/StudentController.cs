using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using automapper_sample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace automapper_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<controller>  
        [HttpGet]
        public StudentDTO Get()
        {
            Address address = new Address()
            {
                State="UP",
                Country="India"
            };
            Student studentDTO = new Student()
            {
                Name = "Student 1",
                Age = 25,
                City = "New York",
                Address = address
            };

            return _mapper.Map<StudentDTO>(studentDTO);
        }

    }
}