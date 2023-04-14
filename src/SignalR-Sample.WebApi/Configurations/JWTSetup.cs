using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SignalR_Sample.WebApi.Application;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Options;

namespace SignalR_Sample.WebApi.Configurations
{
    public static class JWTSetup
    {
        public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            //var sp = services.BuildServiceProvider();
            //JwtSettings configs = 
            //    sp.GetService<IOptions<JwtSettings>>().Value;

            var key =
                Encoding.UTF8.GetBytes(configuration.GetOptions<JwtSettings>(ConstData.JwtSettings).JWTSecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = async context =>
                    {
                        var accessToken =  context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/messageHub"))) 
                        {
                            context.Token = accessToken;
                        }
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromMinutes(configuration.GetOptions<JwtSettings>(ConstData.JwtSettings).JWTLifespan),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
