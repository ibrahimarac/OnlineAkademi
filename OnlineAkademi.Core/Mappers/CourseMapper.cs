using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class CourseMapper:Profile
    {
        public CourseMapper()
        {
            //Entity To Dto
            CreateMap<Course, CourseDto>()
                .ForMember(dto=>dto.CategoryName,e=>e.MapFrom(e=>e.Category.Name));
            CreateMap<Course, ListCourseDto>()
                .ForMember(dto => dto.Trainer, e => e.MapFrom(e => e.Trainer.FirstName+" "+e.Trainer.LastName));

            //Dto to Entity
            CreateMap<CourseDto, Course>();
            CreateMap<ListCourseDto, Course>();
        }
    }
}
