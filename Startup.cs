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
            services.AddScoped<Seed>(); // ����������� ������ Seed
            services.AddScoped<IEducationalProgramRepository, EducationalProgramRepository>(); // ����������� ���������� ��������� �� � ��� ����������
            services.AddScoped<IEducationalProgramService, EducationalProgramService>(); // ����������� ���������� ������� �� � ��� ����������
            services.AddScoped<IModuleRepository, ModuleRepository>(); // ����������� ���������� ��������� ������� � ��� ����������
            services.AddScoped<IModuleService, ModuleService>(); // ����������� ���������� ������� ������� � ��� ����������
            services.AddScoped<IInstituteRepository, InstituteRepository>(); // ����������� ���������� ��������� ���������� � ��� ����������
            services.AddScoped<IHeadRepository, HeadRepository>(); // ����������� ���������� ��������� ������������ ��� � ��� ����������
            services.AddScoped<IEducationalProgramModuleRepository, EducationalProgramModuleRepository>(); // ����������� ���������� ��������� �������� ������ � �� � ��� ����������
            services.AddScoped<IEducationalProgramModuleService, EducationalProgramModuleService>(); // ����������� ���������� ������� �������� ������ � �� � ��� ����������
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // ����������� AutoMapper
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
