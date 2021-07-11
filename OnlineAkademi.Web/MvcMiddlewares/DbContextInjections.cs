
using OnlineAkademi.Data.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class DbContextInjections
    {
        public static IServiceCollection AddLocalDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<IlknurContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalSql"));
            });
        }

    }
}
