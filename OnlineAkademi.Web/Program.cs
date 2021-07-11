using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Core.Loggers;
using OnlineAkademi.Data.Sql.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host=CreateHostBuilder(args).Build();

            //Kullanýcý ve rol tablolarýna varsayýlan kullanýcý ve roller ekleniyor.

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await UserAndRoleSeeder.InitializeAsync(userManager, rolesManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<IExceptionLogger>();
                    logger.LogException(new ErrorDto
                    {
                        CreateDate = DateTime.Now,
                        Exception = ex.Message,
                        IsAjaxRequest = false,
                        QueryString = "",
                        RequestType=RequestType.GET,
                        StatusCode=500,
                        Url="Program.cs Main method",
                        Username=""
                    }) ;
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
