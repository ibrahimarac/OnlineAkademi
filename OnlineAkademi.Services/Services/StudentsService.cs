using OnlineAkademi.Core;
using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineAkademi.Core.Domain.Entities;
using System.Linq;
using OnlineAkademi.Core.Services;
using AutoMapper;
using OnlineAkademi.Core.Mappers;
using OnlineAkademi.Core.Domain.Common;

namespace OnlineAkademi.Services.Services
{
    public class StudentsService : IStudentService
    {
        private readonly IUnitWork Database;
        private readonly IMapper Mapper;
        
        public StudentsService(IUnitWork uWork, IMapper mapper)
        {
            Database = uWork;
            Mapper = mapper;
        }

        public void AddStudent(StudentDto studentDto)
        {
            var student = Mapper.Map<StudentDto, Student>(studentDto);
            Database.StudentRepo.Insert(student);
            Database.Commit();
        }
    }
}
