using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Urfu.Data;
using Urfu.Helper;
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
            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddScoped<IUserServices, UserServices>(); // ����������� ���������� ��������� ������������ � ��� ����������
            services.AddScoped<IUserRepository, UserRepository>(); // ����������� ���������� �������� ������������ � ��� ����������
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
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
