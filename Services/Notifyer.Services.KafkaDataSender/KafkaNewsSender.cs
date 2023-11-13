using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Notifyer.Services.KafkaDataSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataSender
{
    internal class KafkaNewsSender : INewsSender
    {
        private readonly IProducer<Ignore, NewsModel> _producer;
        private readonly IConfiguration _configuration;

        public KafkaNewsSender(IProducer<Ignore, NewsModel> producer, IConfiguration configuration)
        {
            _producer = producer;
            _configuration = configuration;
        }

        public async Task SendAsync(NewsModel model)
        {
            var topic = _configuration.GetSection("NewsTopic").Value;
            var message = new Message<Ignore, NewsModel>()
            {
                Value = model
            };
            await _producer.ProduceAsync(topic, message);
        }
    }
}
