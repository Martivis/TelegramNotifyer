using Notifyer.Services.KafkaDataSender.Models;

namespace Notifyer.Services.KafkaDataSender
{
    public interface INewsProvider
    {
        Task<NewsModel> GetNewsModelAsync();
    }
}