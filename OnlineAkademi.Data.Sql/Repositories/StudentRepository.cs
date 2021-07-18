using Microsoft.EntityFrameworkCore;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AkademiContext context):base(context)
        {
            
        }

        public Student GetStudentWithCourses(string studentId)
        {
            var student=Context.Students.Include("StudentCourses").SingleOrDefault(s=>s.UserName==studentId);
            return student;
        }
    }
}
