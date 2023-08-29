namespace Notifyer.Services.Subscriptions
{
    public interface ISubscriptionsService
    {
        Task SubscribeAsync(long chatId, string cathegoryName);
    }
}