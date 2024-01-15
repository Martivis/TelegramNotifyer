using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notifyer.Data.Context
{
    public static class Bootstraper
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine(configuration.GetConnectionString("Subscribtions"));
            services.AddDbContextFactory<AppDbContext>(opt => 
                opt.UseNpgsql(configuration.GetConnectionString("Subscribtions"))
                   //.EnableSensitiveDataLogging()
            );

            return services;
        }
    }
}
