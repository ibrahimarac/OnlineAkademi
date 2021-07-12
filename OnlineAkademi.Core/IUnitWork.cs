using OnlineAkademi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core
{
    public interface IUnitWork:IDisposable
    {
        ICategoryRepository CategoryRepo { get; }

        ICourseRepository CourseRepo { get; }

        ITrainerRepository TrainerRepo { get; }

        IErrorRepository ErrorRepo { get; }

        ICrudLoggerRepository CrudLoggerRepo { get; set; }

        bool Commit();
        Task<bool> CommitAsync();
    }

}
