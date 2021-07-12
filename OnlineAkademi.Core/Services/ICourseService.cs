using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();

        Task<IEnumerable<CourseDto>> GetCourseWithCourseName();

        CourseDto GetCourseById(int? courseId, bool isTracking = true);

        void AddCourse(CourseDto courseDto);

        void UpdateCourse(CourseDto categoryDto);

        void DeleteCourse(int? courseId);
    }
}
