using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class TrainerInCourseMapper : Profile
    {
        public TrainerInCourseMapper()
        {
            //Entity To Dto
            CreateMap<TrainerInCourse, TrainerInCourseDto>();

            //Dto to Entity
            CreateMap<TrainerInCourseDto, TrainerInCourse>();
        }
    }
}
