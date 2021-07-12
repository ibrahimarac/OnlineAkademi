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

        public bool AddTrainerToCourse(string trainerId, int courseId)
        {
            var course = Context.Courses.SingleOrDefault(c => c.Id == courseId);
            var trainer = Context.Trainers.SingleOrDefault(t => t.UserName == trainerId);
            if (course == null || trainer == null)
                return false;
            course.TrainerId = trainerId;
            return true;
        }

        public bool RemoveTrainerFromCourse(string trainerId, int courseId)
        {
            var course = Context.Courses.SingleOrDefault(c => c.Id == courseId);
            var trainer = Context.Trainers.SingleOrDefault(t => t.UserName == trainerId);
            if (course == null||trainer==null)
                return false;
            course.TrainerId = null;
            return true;
        }

        public async Task<IEnumerable<Course>> GetCoursesNoTrainer(string id)
        {
            var courseForThisTrainer = await Context.Trainers.Include("Courses").Where(t => t.UserName == id).SelectMany(t=>t.Courses).ToListAsync();
            var courseHasNoTrainers = await Context.Courses.Include("Trainer").Where(c => c.Trainer == null).ToListAsync();
            var courses = courseForThisTrainer.Union(courseHasNoTrainers);
            return courses;
        }

        
    }
}
