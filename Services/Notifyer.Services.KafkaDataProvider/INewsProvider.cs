using Notifyer.Services.KafkaDataProvider.Models;

namespace Notifyer.Services.KafkaDataProvider
{
    public interface INewsProvider
    {
        void Subscribe(Action<NewsModel> action);
    }
}