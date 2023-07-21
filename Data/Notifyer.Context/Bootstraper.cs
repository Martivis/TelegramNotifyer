using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notifyer.Context
{
    public static class Bootstraper
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AppDbContext>(opt => 
                opt.UseNpgsql(configuration.GetConnectionString("Subscribtions"))
                   .EnableSensitiveDataLogging()
            );

            return services;
        }
    }
}
