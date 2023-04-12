using Microsoft.EntityFrameworkCore;
using SignalR_Sample.WebApi.Application;
using SignalR_Sample.WebApi.Infrastructure.Context;

namespace SignalR_Sample.WebApi.Configurations
{
    public static class DatabaseSetup
    {
        /// <summary>
        /// Extention Method to Setup Database
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            string? connString =
                configuration.GetConnectionString(ConstData.Connection);

            services.AddDbContext<SignalRSampleContext>(options =>
            {
                options.UseSqlServer(connString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
