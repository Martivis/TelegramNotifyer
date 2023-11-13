using Notifyer.Services.KafkaDataProvider;
using Notifyer.Services.Notifications;
using Notifyer.Services.TelegramService;

namespace Notifyer.Systems.TgNotifyer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly INewsProvider _newsProvider;
        private readonly INotificationsService _notificationsService;
        private readonly ITelegramService _telegramService;

        public Worker(ILogger<Worker> logger, INewsProvider newsProvider, INotificationsService notificationsService, ITelegramService telegramService)
        {
            _logger = logger;
            _newsProvider = newsProvider;
            _notificationsService = notificationsService;
            _telegramService = telegramService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _telegramService.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                var newsModel = await _newsProvider.GetNewsModelAsync();
                await _notificationsService.HandleNotification(newsModel);
                _logger.LogInformation("Notification sent at: {time}", DateTimeOffset.Now);
                await Task.Delay(20000, stoppingToken);
            }
        }
    }
}