using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using automapper_sample.Model;
using Microsoft.Extensions.DependencyInjection;
using automapper_sample.Services.Students;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(AzFunction.Startup))]
namespace AzFunction
{
    class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Adding automapper
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Entities.Skill, SkillDTO>().ReverseMap();
                //cfg.CreateMap<Entities.Skill, SubSkillDTO>().ReverseMap();
                //cfg.CreateMap<Entities.Industry, IndustryDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();

            });
            IMapper iMapper = config.CreateMapper();

            builder.Services.AddSingleton<IMapper>(iMapper);
            string connectionString = Environment.GetEnvironmentVariable("MyWebApiConection");

            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MasterDbContext>(opt => opt.UseNpgsql(connectionString));

            builder.Services.AddScoped<IStudentService, StudentService>();

        }
    }
}
