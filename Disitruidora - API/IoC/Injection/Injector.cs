using System;
using System.Collections.Generic;
using System.Text;
using Application.AppService;
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using InfraData.DataContext;
using InfraData.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UoW.UoW;

namespace IoC.Injection
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IArmazemAppService, ArmazemAppService>();
            services.AddScoped<IArmazemRepository, ArmazemRepository>();
            services.AddScoped<IArmazemService, ArmazemService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataBaseContext>();

        }
    }
}
