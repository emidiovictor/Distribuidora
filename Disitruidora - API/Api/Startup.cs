﻿using System;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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
                    //.UseLazyLoadingProxies()
                    .UseNpgsql(connectionString));

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });


            services.AddScoped<IArmazemAppService, ArmazemAppService>();
            services.AddScoped<IArmazemRepository, ArmazemRepository>();
            services.AddScoped<IArmazemService, ArmazemService>();
            services.AddScoped<DataBaseContext>();
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
            Mapper.Initialize(cfg => cfg.AddProfile<DtoToDomainProfile>());


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

        }
    }
}