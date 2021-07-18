using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Repositories
{
    public interface IStudentRepository:IRepository<Student>
    {
        Student GetStudentWithCourses(string studentId);
    }
}
