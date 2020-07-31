using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using automapper_sample.Services.Students;
using automapper_sample.Model;
using System.Collections.Generic;

namespace AzFunction
{
    public  class CreateStudent
    {
        private readonly IStudentService _studentService;

        public CreateStudent(IStudentService studentService) 
        {
            this._studentService = studentService;
        }

        [FunctionName("CreateStudent")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateStudent")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Student languages = JsonConvert.DeserializeObject<Student>(requestBody);
            IEnumerable<StudentDTO> language = await _studentService.CreateStudent(languages); 

            return new OkObjectResult(language);
        }

        [FunctionName("GetStudents")]
        public async Task<IActionResult> GetStudents(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetStudents")] HttpRequest req,
          ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                IEnumerable<StudentDTO> response = await _studentService.GetStudent();
                return new OkObjectResult(response);
            }
            catch (Exception exception)
            {
                log.LogDebug(exception.Message);
               
                return new BadRequestObjectResult(exception);
            }
        }
    }
}
