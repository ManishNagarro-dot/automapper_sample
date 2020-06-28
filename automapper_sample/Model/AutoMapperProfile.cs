using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace automapper_sample.Model
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student,StudentDTO>()
                .ForMember(dest=>dest.CurrentCity,opt=>opt.MapFrom(src=>src.City));

            CreateMap<Address, AddressDTO>();

        }
    }
}
