using MediatR;
using SignalR_Sample.WebApi.Application;
using SignalR_Sample.WebApi.Configurations;
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
                    configuration.GetOptions<JwtSettings>(ConstData.JwtSettings).JWTSecretKey,
                    configuration.GetOptions<JwtSettings>(ConstData.JwtSettings).RefreshTokenTimeout)
                );

            services.AddMediatR(typeof(DependencyInjection).GetTypeInfo().Assembly);
           
            return services;
        }
    }
}
