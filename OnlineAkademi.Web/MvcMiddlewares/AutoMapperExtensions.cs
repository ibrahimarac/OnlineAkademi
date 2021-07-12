using OnlineAkademi.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            return
                services.AddAutoMapper(
                    typeof(CategoryMapper),
                    typeof(Startup)
                );
        }
    }
}
