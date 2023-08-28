namespace Notifyer.Services.TelegramService
{
    public interface ITelegramService
    {
        void Start();
        Task SendMessageAsync(long chatId, string message);
    }
}