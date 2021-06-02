using AutoMapper;
using StoneChallenge_Payslip.Application.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoneChallenge_Payslip.Infra.Data.Context;
using Autofac;
using StoneChallenge_Payslip.Infra.CrossCutting.IoC;
using System;
using static Domain.Enums.PayslipEnums;

namespace StoneChallenge_Payslip.Application
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
                var host = Configuration["MySQL_server"] ?? "localhost";
                var port = Configuration["MySQL_port"] ?? "3306";
                var password = Configuration["MySQL_password"] ?? Configuration.GetConnectionString("MYSQL_PASSWORD");
                var userid = Configuration["MySQL_username"] ?? Configuration.GetConnectionString("MYSQL_USER");
                var userDataBase = Configuration["MySQL_database"] ?? Configuration.GetConnectionString("MYSQL_DATABASE");

                var stringConnection = $"server={host};userid={userid};pwd={password};port={port};database={userDataBase}";

                try
                {
                    options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection), opt =>
                    {
                        opt.CommandTimeout(180);
                        opt.EnableRetryOnFailure(5);
                    });

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " " + stringConnection);
                }
            });

            services.AddSingleton(new MapperConfiguration(config =>
            {
                #region Employee

                config.CreateMap<CreateEmployee, Domain.Entities.Employee>();
                config.CreateMap<Domain.Entities.Employee, Employee>();

                config.CreateMap<Domain.Entities.Payslip, Payslip>();
                config.CreateMap<Domain.Entities.Payslip.Entry, Payslip.Entry>().ForMember(x => x.Type,
                 opt => opt.MapFrom(source => source.Type == EntryType.Discount ? "Desconto" : "Remuneração")); ;

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API StoneChallenge_Payslip");
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
