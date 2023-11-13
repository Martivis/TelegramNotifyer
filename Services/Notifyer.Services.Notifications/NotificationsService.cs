using Microsoft.EntityFrameworkCore;
using Notifyer.Data.Context;
using Notifyer.Data.Context.Entities;
using Notifyer.Services.KafkaDataProvider.Models;
using Notifyer.Services.TelegramService;

namespace Notifyer.Services.Notifications
{
    public class NotificationsService : INotificationsService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly IMessageProvider _messageProvider;
        private readonly ITelegramService _telegramService;

        public NotificationsService(
            IDbContextFactory<AppDbContext> dbContextFactory,
            IMessageProvider messageProvider,
            ITelegramService telegramService)
        {
            _contextFactory = dbContextFactory;
            _messageProvider = messageProvider;
            _telegramService = telegramService;
        }

        public async Task HandleNotification(NewsModel model)
        {
            using var context = _contextFactory.CreateDbContext();

            var subscribers = await context.Set<UserData>()
                .Include(user => user.SubscribedCathegories)
                .Where(user => user.SubscribedCathegories.Any(cathegory => cathegory.Name == model.Cathegory))
                .ToListAsync();

            foreach (var subscriber in subscribers)
            {
                await SendNotificationAsync(model, subscriber.ChatId);
            }
        }

        private async Task SendNotificationAsync(NewsModel model, long chatId)
        {
            var message = _messageProvider.GetMessage(model);
            await _telegramService.SendMessageAsync(chatId, message);
        }
    }
}