using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class StudentInCourseMapper:Profile
    {
        public StudentInCourseMapper()
        {
            //Entity To Dto
            CreateMap<StudentInCourse, StudentInCourseDto>();

            //Dto to Entity
            CreateMap<StudentInCourseDto, StudentInCourse>();
        }
    }
}
