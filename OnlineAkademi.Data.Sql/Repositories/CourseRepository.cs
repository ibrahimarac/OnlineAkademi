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
    }
}
