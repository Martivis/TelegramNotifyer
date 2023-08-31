using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.Notifications
{
    public static class Bootstraper
    {
        public static IServiceCollection AddNotificationService(this IServiceCollection services)
        {
            services.AddSingleton<INotificationsService, NotificationsService>();
            services.AddSingleton<IMessageProvider, MessageProvider>();
            return services;
        }
    }
}
