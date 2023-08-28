using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Notifyer.Services.TelegramService
{
    internal class TelegramService : ITelegramService
    {
        private readonly TelegramBotClient _client;
        private CancellationTokenSource _tokenSource;
        private ReceiverOptions _receiverOptions;

        public TelegramService(string token)
        {
            _client = new TelegramBotClient(token);
            _tokenSource = new CancellationTokenSource();
            _receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
        }

        public void Start()
        {
            _client.StartReceiving(receiverOptions: _receiverOptions,
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandleErrorAsync,
                cancellationToken: _tokenSource.Token);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;

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
