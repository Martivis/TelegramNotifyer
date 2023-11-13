using Notifyer.Services.KafkaDataSender.Models;

namespace Notifyer.Services.KafkaDataSender
{
    public interface INewsSender
    {
        Task SendAsync (NewsModel model);
    }
}