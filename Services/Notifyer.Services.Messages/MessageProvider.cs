using Notifyer.Services.KafkaDataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.Messages
{
    internal class MessageProvider : IMessageProvider
    {
        public string GetMessage(NewsModel model)
        {
            return $"{model.Title}\n\n{model.Content}\n\n{model.Cathegory}";
        }
    }
}
