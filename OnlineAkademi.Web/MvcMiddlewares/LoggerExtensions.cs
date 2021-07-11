using OnlineAkademi.Core.Loggers;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Services.Services;
using OnlineAkademi.Utils.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class LoggerExtensions
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            return
                services
                    .AddScoped<IExceptionLogger, DbExceptionLogger>()
                    .AddScoped<ICrudOperationLogger, DbCrudOperationLogger>();
        }
    }
}
