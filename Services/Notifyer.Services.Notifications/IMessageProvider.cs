using Notifyer.Services.KafkaDataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.Notifications
{
    public interface IMessageProvider
    {
        string GetMessage(NewsModel model);
    }
}
