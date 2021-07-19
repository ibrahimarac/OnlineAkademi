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

        public IEnumerable<Course> GetActiveCoursesForStudents(string studentId)
        {
            var courses = Context.Courses.Include("Trainer").Include("CourseStudents").Where(c => c.CourseStudents.Count(cs => cs.StudentId == studentId) > 0 && c.EndDate<=DateTime.Now);

            return courses;
        }

        public IEnumerable<Course> GetFinishedCoursesForStudents(string studentId)
        {
            var courses = Context.Courses.Include("Trainer").Include("CourseStudents").Where(c => c.CourseStudents.Count(cs => cs.StudentId == studentId) > 0 && c.EndDate > DateTime.Now);

            return courses;
        }

    }
}
