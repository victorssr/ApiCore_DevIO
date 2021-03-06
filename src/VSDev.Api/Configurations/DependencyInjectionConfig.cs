﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using VSDev.Api.Data;
using VSDev.Api.Extensions;
using VSDev.Business.Interfaces;
using VSDev.Business.Interfaces.Repositories;
using VSDev.Business.Interfaces.Services;
using VSDev.Business.Notifications;
using VSDev.Business.Services;
using VSDev.Data.Context;
using VSDev.Data.Repositories;

namespace VSDev.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDepedencies(this IServiceCollection services)
        {
            services.AddScoped<ContextBase>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<INotificator, Notificator>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AppUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // REPOSITORIES
            services.AddScoped<ICasaRepository, CasaRepository>();
            services.AddScoped<IDespesaIndividualRepository, DespesaIndividualRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IMoradorRepository, MoradorRepository>();

            // SERVICES
            services.AddScoped<ICasaService, CasaService>();
            services.AddScoped<IDespesaIndividualService, DespesaIndividualService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IMoradorService, MoradorService>();

            return services;
        }
    }
}
