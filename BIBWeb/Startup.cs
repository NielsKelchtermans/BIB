using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BIBData.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using BIBServices;
using BIBData.Repositories;

namespace BIBWeb
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
            services.AddControllersWithViews();
            //DbContext (met een configuration connection strings)
            services.AddDbContext<BIBDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BIBConnection")));
            //De BIBServices injecteren, elke keer een nieuwe (Transient)
            services.AddTransient<LenerService>();
            services.AddTransient<ILenerRepository, SQLLenerRepository>();
            services.AddTransient<IUitleenobjectRepository, SQLUitleenobjectRepository>();
            services.AddTransient<UitleenObjectService>();
            services.AddTransient<UitleningService>();
            services.AddTransient<IUitleningRepository, SQLUitleningRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
