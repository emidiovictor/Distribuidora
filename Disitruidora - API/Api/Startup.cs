using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AppService;
using Application.AutoMapper;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using InfraData.DataContext;
using InfraData.Repositories;
using IoC.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using UoW.UoW;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            const string connectionString = "User ID=postgres;Password=masterkey;Host=localhost;Port=5432;Database=distri;Pooling=true;";


            services.AddDbContext<DataBaseContext>(options =>
                options
                    .UseNpgsql(connectionString));


            services.AddSwaggerGen
                (c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Armazens", Version = "Alpha" }); 

            });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });


            services.AddDI();
            services.AddAutoMapper();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAll");

            app.UseSwagger();


            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DtoToDomainProfile>();
                cfg.AddProfile<DomainToDtoProfile>();
            } );
          



            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

        }
    }
}