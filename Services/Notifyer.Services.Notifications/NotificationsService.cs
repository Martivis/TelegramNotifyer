using Microsoft.EntityFrameworkCore;
using Notifyer.Data.Context;
using Notifyer.Data.Context.Entities;
using Notifyer.Services.KafkaDataProvider.Models;
using Notifyer.Services.Messages;

namespace Notifyer.Services.Notifications
{
    public class NotificationsService
    {
        private readonly AppDbContext _context;
        private readonly IMessageProvider _messageProvider;
        private readonly IMessageSender _messageSender;

        public NotificationsService(
            AppDbContext dbContext, 
            IMessageProvider messageProvider, 
            IMessageSender messageSender)
        {
            _context = dbContext;
            _messageProvider = messageProvider;
            _messageSender = messageSender;
        }

        public async Task HandleNotification(NewsModel model)
        {
            var subscribers = await _context.Set<UserData>()
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
            await _messageSender.SendAsync(message, chatId);
        }
    }
}