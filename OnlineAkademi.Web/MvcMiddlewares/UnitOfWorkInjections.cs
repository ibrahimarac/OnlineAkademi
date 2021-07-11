using OnlineAkademi.Core;
using OnlineAkademi.Data.Sql;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class UnitOfWorkInjections
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitWork, UnitWork>();
        }
    }
}
