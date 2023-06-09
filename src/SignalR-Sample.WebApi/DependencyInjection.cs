﻿using MediatR;
using SignalR_Sample.WebApi.Application;
using SignalR_Sample.WebApi.Application.Interfaces;
using SignalR_Sample.WebApi.Application.Queries;
using SignalR_Sample.WebApi.Configurations;
using SignalR_Sample.WebApi.Domain;
using SignalR_Sample.WebApi.Hubs;
using SignalR_Sample.WebApi.Infrastructure.Repositories;
using System.Reflection;

namespace SignalR_Sample.WebApi
{
    public static class DependencyInjection
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
          where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }

        public static IServiceCollection RegisterServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // var sp = services.BuildServiceProvider();

            services.AddSingleton<JwtSettings>(
                new JwtSettings(
                    configuration.GetOptions<JwtSettings>(ConstData.JwtSettings).JWTLifespan,
                    configuration.GetOptions<JwtSettings>(ConstData.JwtSettings).JWTSecretKey)
                );

            services.AddMediatR(typeof(GetTokenQuery).GetTypeInfo().Assembly);

            services.AddScoped<IPerson, PersonRepository>();
            services.AddScoped<IMessage, MessageRepository>();
            services.AddScoped<IMessageHub, MessageHub>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
