using Notifyer.Data.UserDataRepository;
using Notifyer.Services.KafkaDataProvider;
using Notifyer.Services.KafkaDataProvider.Models;
using Notifyer.Services.Messages;

namespace Notifyer.Services.Notifications
{
    public class NotificationsManager
    {
        private readonly INewsProvider _provider;
        private readonly IUserDataRepository _userRepository;
        private readonly IMessageProvider _messageProvider;
        private readonly IMessageSender _messageSender;

        public NotificationsManager(
            INewsProvider provider, 
            IUserDataRepository userRepository, 
            IMessageProvider messageProvider, 
            IMessageSender messageSender)
        {
            _provider = provider;
            _userRepository = userRepository;
            _messageProvider = messageProvider;
            _messageSender = messageSender;
        }

        public void Subscribe()
        {
            _provider.Subscribe(NotificationHandler);
        }

        private async void NotificationHandler(NewsModel model)
        {
            var subscribers = await _userRepository.GetByCathegoryAsync(model.Cathegory);
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