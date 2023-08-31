using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.TelegramService
{
    public static class Bootstraper
    {
        public static IServiceCollection AddTelegramService(this IServiceCollection services)
        {
            services.AddSingleton<ITelegramService, TelegramService>();
            return services;
        }
    }
}
