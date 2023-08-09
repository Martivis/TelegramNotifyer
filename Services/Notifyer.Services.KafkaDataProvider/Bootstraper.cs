using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataProvider
{
    public static class Bootstraper
    {
        public static IServiceCollection AddMockNewsProvider(IServiceCollection services)
        {
            services.AddSingleton<INewsProvider, MockNewsProvider>();
            return services;
        }
    }
}
