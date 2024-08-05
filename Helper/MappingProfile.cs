using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Dto;
using Urfu.Models;

namespace Urfu.Helper
{
    public class MappingProfile: Profile // класс содержащий карты структур (преобразования одних структур в другие)
    {
        public MappingProfile() 
        {
            CreateMap<EducationalProgram, EducationalProgramDto>();
            CreateMap<EducationalProgramDto, EducationalProgram>();
            CreateMap<EducationalProgramAddDto, EducationalProgram>();

            CreateMap<Module, ModuleDto>();
            CreateMap<ModuleDto, Module>();
        }
    }
}
