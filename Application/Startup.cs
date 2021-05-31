using AutoMapper;
using WarzoneLobbyOrganizer.Application.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WarzoneLobbyOrganizer.Infra.Data.Context;
using Autofac;
using WarzoneLobbyOrganizer.Infra.CrossCutting.IoC;

namespace WarzoneLobbyOrganizer.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIoCService());
            builder.RegisterModule(new ModuleIoCRepository());
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Payslip", Version = "v1" });
            });

            services.AddDbContext<MySqlContext>(options =>
            {
                var stringConnection = "Server=localhost;Port=3306;user=root;password=M36nbp7@1;database=WarzoneLobbyDB";

                options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddSingleton(new MapperConfiguration(config =>
            {
                #region Employee

                config.CreateMap<CreateEmployee, Domain.Entities.Employee>();                
                config.CreateMap<Domain.Entities.Employee, Employee>();
                
                #endregion

            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API WarzoneLobbyOrganizer");
            });

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
