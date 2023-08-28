namespace ISubscriptionsService
{
    public interface ISubscriptionsService
    {
        Task SubscribeAsync(long chatId, string cathegoryName);
    }
}