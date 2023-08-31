using Microsoft.Extensions.Configuration;
using Notifyer.Services.Subscriptions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Notifyer.Services.TelegramService
{
    internal class TelegramService : ITelegramService
    {
        private const string TOKEN_SECTION_NAME = "TelegramBotToken";

        private readonly ISubscriptionsService _subscriptionsService;
        private readonly IConfiguration _configuration;

        private TelegramBotClient _client;
        private readonly CancellationTokenSource _tokenSource;
        private readonly ReceiverOptions _receiverOptions;

        public TelegramService(ISubscriptionsService subscriptionsService, IConfiguration configuration)
        { 
            _subscriptionsService = subscriptionsService;
            _configuration = configuration;

            _tokenSource = new CancellationTokenSource();
            _receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
        }

        public void Start()
        {
            var token = _configuration.GetSection(TOKEN_SECTION_NAME).Value
                ?? throw new Exception($"Missing section {TOKEN_SECTION_NAME} in configuration");
            _client = new TelegramBotClient(token);

            _client.StartReceiving(receiverOptions: _receiverOptions,
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandleErrorAsync,
                cancellationToken: _tokenSource.Token);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            if (message == null)
                return;

            if (message.Text?.StartsWith("+") ?? false)
            {
                var chatId = message.From!.Id;
                var cathegoryName = message.Text[1..].Trim();

                try
                {
                    await _subscriptionsService.SubscribeAsync(chatId, cathegoryName);

                    await client.SendTextMessageAsync(chatId, $"Successful subscribed to {cathegoryName}");
                }
                catch (ApplicationException ex)
                {
                    await client.SendTextMessageAsync(chatId, ex.Message);
                }
            }

        }

        private async Task HandleErrorAsync(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {

        }

        public async Task SendMessageAsync(long chatId, string message)
        {
            await _client.SendTextMessageAsync(chatId, message);
        }
    }
}
