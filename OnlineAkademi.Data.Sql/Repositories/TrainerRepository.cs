using Microsoft.EntityFrameworkCore;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.Repositories
{
    public class TrainerRepository:Repository<Trainer>,ITrainerRepository
    {
        public TrainerRepository(AkademiContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Course>> GetCoursesByTrainer(string id)
        {
            var courses = await Context.TrainerInCourses.Include("Course").Where(c => c.TrainerId == id).Select(c=>c.Course).ToListAsync();
            return courses;
        }
    }
}
