using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Mappings
{
    public class CourseMappings:Profile
    {
        public CourseMappings()
        {
            CreateMap<CourseDto, CourseVM>();
            CreateMap<CourseVM, CourseDto>();

            CreateMap<ListCourseDto, ListCourseVM>();
            CreateMap<ListCourseVM, ListCourseDto>();
        }
    }
}
