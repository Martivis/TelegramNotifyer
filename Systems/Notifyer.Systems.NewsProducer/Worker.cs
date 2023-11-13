using Notifyer.Services.KafkaDataSender;
using System.Data;

namespace Notifyer.Systems.NewsProducer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly INewsProvider _newsProvider;
        private readonly INewsSender _newsSender;

        public Worker(ILogger<Worker> logger, INewsProvider newsProvider, INewsSender newsSender)
        {
            _logger = logger;
            _newsProvider = newsProvider;
            _newsSender = newsSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var model = await _newsProvider.GetNewsModelAsync();
                await _newsSender.SendAsync(model);

                _logger.LogInformation("Message sent at: {time}", DateTimeOffset.Now);
                await Task.Delay(15000, stoppingToken);
            }
        }
    }
}