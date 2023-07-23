using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataProvider.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Cathegory { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
