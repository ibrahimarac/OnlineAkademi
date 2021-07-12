using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Repositories
{
    public interface ICourseRepository:IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesWithName();
    }
}
