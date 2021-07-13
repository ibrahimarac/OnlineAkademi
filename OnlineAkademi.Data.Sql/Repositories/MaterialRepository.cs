using Microsoft.EntityFrameworkCore;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Repositories;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.Repositories
{
    public class MaterialRepository : Repository<CourseMaterial>,IMaterialRepository
    {
        public MaterialRepository(AkademiContext context) : base(context)
        {

        }        

    }
}
