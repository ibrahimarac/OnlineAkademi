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

        public void BuyCourse(string studentId, int? courseId)
        {
            if (courseId == null)
                throw new ParameterException("Id", "Student", "Kurs numarası gönderilmedi.");
            var course = Database.CourseRepo.GetById(courseId.Value);
            if (course == null)
                throw new ParameterException("Id", "Student", "Gönderilen kurs numarası geçerli değil.");

            if (studentId == null)
                throw new ParameterException("Id", "Student", "Öğrenci numarası gönderilmedi.");
            var student = Database.StudentRepo.GetSingle(s => s.UserName == studentId);
            if (student == null)
                throw new ParameterException("Id", "Student", "Gönderilen öğrenci numarası geçerli değil.");

            //Öğrenciyi ilgili kursa ekleyelim
            var studentWithCourses=Database.StudentRepo.GetStudentWithCourses(studentId);
            studentWithCourses.StudentCourses.Add(new StudentInCourse { 
                StudentId=studentId,
                CourseId=courseId.Value
            });

            Database.Commit();
        }
    }
}
