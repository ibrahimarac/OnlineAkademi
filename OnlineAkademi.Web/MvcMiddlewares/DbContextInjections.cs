
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Data.Sql;
using OnlineAkademi.Data.Sql.Identity;
using System;

namespace OnlineAkademi.Web.MvcMiddlewares
{
    public static class DbContextInjections
    {
        public static IServiceCollection AddLocalDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AkademiContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalDb"));
            });
        }

        public static void AddLocalIdentityContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalIdentityDb"));                
            })
                .ConfigureApplicationCookie(opt =>
                {
                    opt.Cookie.Name = "user";
                    opt.LoginPath = "/Account/Login";
                    // Cookie settings
                    opt.Cookie.HttpOnly = true;
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    opt.SlidingExpiration = true;
                    opt.LoginPath = "/Account/Login/";
                })
                .AddIdentity<AppUser, IdentityRole>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 4;                    
                })
                .AddEntityFrameworkStores<IdentityContext>();
        }

    }
}
