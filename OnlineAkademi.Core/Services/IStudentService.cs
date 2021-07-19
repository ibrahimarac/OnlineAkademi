using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface IStudentService
    {
        void AddStudent(StudentDto studentDto);

        void BuyCourse(string studentId, int? courseId);

        IEnumerable<ListCourseDto> GetActiveCoursesForStudent(string studentId);

        IEnumerable<ListCourseDto> GetFinishedCoursesForStudent(string studentId);

    }
}
