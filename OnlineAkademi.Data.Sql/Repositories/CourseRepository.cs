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
    public class CourseRepository : Repository<Course>,ICourseRepository
    {
        public CourseRepository(AkademiContext context):base(context)
        {

        }

        public async Task<IEnumerable<Course>> GetCoursesWithName()
        {
            var courses= await Context.Courses.Include("Category").ToListAsync();
            return courses;

        }

        public async Task<IEnumerable<Course>> GetCourseWithNameAndStudents()
        {
            var courses = await Context.Courses
                .Include("Category")
                .Include("CourseStudents")
                .Include("Trainer")
                .Where(c=>c.IsActive.Value)
                .ToListAsync();
            return courses;
        }

        public async Task<Course> GetCourseWithNameAndStudentsById(int id)
        {
            var course = await Context.Courses
                .Include("Category")
                .Include("CourseStudents")
                .Include("Trainer")
                .SingleOrDefaultAsync(c => c.Id == id);
                
            return course;
        }

    }
}
