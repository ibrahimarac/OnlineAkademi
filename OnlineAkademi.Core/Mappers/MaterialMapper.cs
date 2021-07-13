using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class MaterialMapper : Profile
    {
        public MaterialMapper()
        {
            //Entity To Dto
            CreateMap<CourseMaterial, MaterialDto>();

            //Dto to Entity
            CreateMap<MaterialDto, CourseMaterial>();
        }
    }
}
