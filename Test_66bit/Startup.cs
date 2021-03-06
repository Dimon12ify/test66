using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test_66bit.Contexts;
using Test_66bit.Interfaces;
using Test_66bit.Models;
using Test_66bit.Repositories;
using Test_66bit.Services;

namespace Test_66bit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, AppDbContext>();
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IFootballerRepository, FootballerRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Footballer}/{action=List}/{id?}");
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}