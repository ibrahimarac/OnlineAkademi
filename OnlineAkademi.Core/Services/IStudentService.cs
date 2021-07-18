using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface IStudentService
    {
        void AddStudent(StudentDto student);

        void BuyCourse(string studentId, int? courseId);
    }
}
