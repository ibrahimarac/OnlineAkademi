using FluentValidation;
using FluentValidation.AspNetCore;
using OnlineAkademi.Web.Models.VM;
using OnlineAkademi.Web.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            return
                services
                    .AddFluentValidation()
                    .AddTransient<IValidator<CategoryVM>, CategoryValidator>();
        }
    }
}
