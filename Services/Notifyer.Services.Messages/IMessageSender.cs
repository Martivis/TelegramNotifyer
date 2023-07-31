using Notifyer.Services.KafkaDataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.Messages
{
    public interface IMessageSender
    {
        Task SendAsync(string message, long chatId);
    }
}
