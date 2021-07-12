using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class StudentMapper:Profile
    {
        public StudentMapper()
        {
            //Entity To Dto
            CreateMap<Student, StudentDto>();

            //Dto to Entity
            CreateMap<StudentDto, Student>();
        }
    }
}
