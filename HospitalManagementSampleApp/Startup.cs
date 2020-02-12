using HospitalManagement.DB;
using HospitalManagement.Domain.Interfaces.Repositories;
using HospitalManagement.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using AutoMapper;

namespace HospitalManagementSampleApp
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public static readonly LoggerFactory MyLoggerFactory
                        = new LoggerFactory(new[]
                        {
                            new ConsoleLoggerProvider((category, level)
                                => category == DbLoggerCategory.Database.Command.Name
                                   && level == LogLevel.Information, true)
                        });
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<HospitalManagementContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(_configuration.GetConnectionString("HospitalManagementDatabase"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IStudyRepository, StudyRepository>();
            services.AddScoped<IDoctorPatientRepository, DoctorPatientRepository>();


            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
