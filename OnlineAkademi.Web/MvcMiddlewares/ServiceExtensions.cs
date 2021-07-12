﻿using OnlineAkademi.Core.Services;
using OnlineAkademi.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineAkademi.Services.Services.Identity;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return
                services
                    .AddScoped<ICategoryService, CategoryService>()
                    .AddScoped<ICourseService,CourseService>()
                    .AddScoped<IAccountService,AccountService>()
                    .AddScoped<IErrorService, ErrorService>()
                    .AddScoped<ILogCrudService, LogCrudService>();
        }
    }
}
