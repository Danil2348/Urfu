using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Data;
using Urfu.Repository;
using Urfu.Service;

namespace Urfu
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
            services.AddScoped<Seed>(); // регистрация класса Seed
            services.AddScoped<IEducationalProgramRepository, EducationalProgramRepository>(); // регистрация интерфейса хранилища ОП и его реализации
            services.AddScoped<IEducationalProgramService, EducationalProgramService>(); // регистрация интерфейса сервиса ОП и его реализации
            services.AddScoped<IModuleRepository, ModuleRepository>(); // регистрация интерфейса хранилища модулей и его реализации
            services.AddScoped<IModuleService, ModuleService>(); // регистрация интерфейса сервиса модулей и его реализации
            services.AddScoped<IInstituteRepository, InstituteRepository>(); // регистрация интерфейса хранилища институтов и его реализации
            services.AddScoped<IHeadRepository, HeadRepository>(); // регистрация интерфейса хранилища ответсвенных лиц и его реализации
            services.AddScoped<IEducationalProgramModuleRepository, EducationalProgramModuleRepository>(); // регистрация интерфейса хранилища привязки модуля с ОП и его реализации
            services.AddScoped<IEducationalProgramModuleService, EducationalProgramModuleService>(); // регистрация интерфейса сервиса привязки модуля с ОП и его реализации
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // подключения AutoMapper
            services.AddControllers();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Urfu", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Urfu v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
