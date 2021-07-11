using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Data.Sql.Repositories
{
    public class ErrorRepository:Repository<Error>,IErrorRepository
    {
        public ErrorRepository(AkademiContext context):base(context)
        {

        }


    }
}
