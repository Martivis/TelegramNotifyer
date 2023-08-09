using Notifyer.Services.KafkaDataProvider.Models;

namespace Notifyer.Services.KafkaDataProvider
{
    public interface INewsProvider
    {
        Task<NewsModel> GetNewsModelAsync();
    }
}