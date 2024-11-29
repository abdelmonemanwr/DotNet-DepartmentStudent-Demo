using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myApp.DTOs;
using myApp.Models;

namespace myApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
            .ForMember(dest => dest.sid, opt => opt.MapFrom(src => src.St_id))
            .ForMember(dest => dest.age, opt => opt.MapFrom(src => src.St_age))
            .ForMember(dest => dest.did, opt => opt.MapFrom(src => src.Dept_id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.St_name))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.St_address))
            .ReverseMap();
        }
    }
}