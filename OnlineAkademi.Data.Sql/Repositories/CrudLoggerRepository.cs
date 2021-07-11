using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.Repositories
{
    public class CrudLoggerRepository:Repository<Log>, ICrudLoggerRepository
    {
        public CrudLoggerRepository(IlknurContext context):base(context)
        {
            
        }

    }
}
