using Notifyer.Services.KafkaDataProvider.Models;

namespace Notifyer.Services.KafkaDataProvider
{
    public interface IDataProvider
    {
        NewsModel GetData();
    }
}