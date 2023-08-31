using Notifyer.Services.KafkaDataProvider.Models;

namespace Notifyer.Services.Notifications
{
    public interface INotificationsService
    {
        Task HandleNotification(NewsModel model);
    }
}