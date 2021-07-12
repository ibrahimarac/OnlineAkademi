using AutoMapper;
using OnlineAkademi.Core;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitWork Database;
        private readonly IMapper Mapper;

        public CourseService(IUnitWork uWork, IMapper mapper)
        {
            Database = uWork;
            Mapper = mapper;
        }

        public void AddCourse(CourseDto courseDto)
        {
            var course = Mapper.Map<CourseDto, Course>(courseDto);
            Database.CourseRepo.Insert(course);
            Database.Commit();
        }

        public void DeleteCourse(string courseId)
        {
            if (courseId==null)
                throw new ParameterException("Id", "Course", "Kurs numarası gönderilmedi.");
            var course = Database.CourseRepo.GetById(int.Parse(courseId));
            if (course == null)
                throw new ParameterException("Id", "Course", "Gönderilen kurs numarası geçerli değil.");

            Database.CourseRepo.Delete(course);
            Database.Commit();
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await Database.CourseRepo.GetAllAsync(false);
            var courseDtos = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
            return courseDtos;
        }

        public CourseDto GetCourseById(string courseId, bool isTracking = true)
        {
            if (courseId==null)
                throw new ParameterException("Id", "Course", "Kurs numarası gönderilmedi.");
            var course = Database.CourseRepo.GetById(int.Parse(courseId), isTracking);
            if (course == null)
                throw new ParameterException("Id", "Course", "Gönderilen kurs numarası geçerli değil.");
            var courseDto = Mapper.Map<Course, CourseDto>(course);
            return courseDto;
        }

        public async Task<IEnumerable<CourseDto>> GetCourseWithCourseName()
        {
            var courses= await Database.CourseRepo.GetCoursesWithName();
            var courseDtos=Mapper.Map<IEnumerable<Course>,IEnumerable<CourseDto>> (courses);
            return courseDtos;
        }

        public void UpdateCourse(CourseDto courseDto)
        {
            if (courseDto.Id == 0)
                throw new ParameterException("Id", "Course", "Güncellenecek kurs numarası gönderilmedi.");
            var course = Mapper.Map<CourseDto, Course>(courseDto);
            Database.CourseRepo.Update(course);
            Database.Commit();
        }

    }
}
