
using OnlineAkademi.Core;
using OnlineAkademi.Data.Sql;
using OnlineAkademi.Utils.Helpers;
using OnlineAkademi.Web.MvcMiddlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalDbContext(Configuration);

            services.AddLocalIdentityContext(Configuration);

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();    

            services.AddRepositories();

            services.AddUnitOfWork();

            services.AddAutoMappers();

            services.AddFluentValidators();

            services.AddBusinessServices();

            services.AddLoggers();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(5);//You can set Time   
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            ServiceActivator.Configure(app.ApplicationServices);

            //app.UseExceptionHandler("/Error/Http500"); //500 numaralý kod çalýþtýrma hatalarý için

            app.UseDeveloperExceptionPage();

            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
