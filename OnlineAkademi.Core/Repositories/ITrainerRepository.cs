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
        Task<IEnumerable<Course>> GetCoursesByTrainer(string id);
    }
}
