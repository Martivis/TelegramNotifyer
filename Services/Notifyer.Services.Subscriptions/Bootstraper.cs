using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.Subscriptions
{
    public static class Bootstraper
    {
        public static IServiceCollection AddSubscriptionsService(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionsService, SubscriptionsService>();
            return services;
        }
    }
}
