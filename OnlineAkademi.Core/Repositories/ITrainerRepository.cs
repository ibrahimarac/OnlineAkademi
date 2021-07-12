using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Repositories
{
    public interface ITrainerRepository:IRepository<Trainer>
    {
        Task<IEnumerable<Course>> GetCoursesNoTrainer(string id);

        bool AddTrainerToCourse(string trainerId, int courseId);

        bool RemoveTrainerFromCourse(string trainerId, int courseId);
    }
}
