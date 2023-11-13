using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Data.Context
{
    public static class AppDbInitializer
    {
        private const int MaxRetries = 5;
        private const int RetryDelayMs = 1000;

        public static void Execute(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();

            var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();

            int retries = 0;
            while (retries < MaxRetries)
            {
                try
                {
                    using var context = dbContextFactory.CreateDbContext();

                    context.Database.EnsureCreated();
                    return;
                }
                catch (Exception e)
                {
                    retries++;
                    Task.Delay(RetryDelayMs).Wait();

                    if (retries >= MaxRetries)
                        throw;
                }
            }
        }
    }
}
