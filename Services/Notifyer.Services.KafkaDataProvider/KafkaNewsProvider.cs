using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Notifyer.Services.KafkaDataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataProvider
{
    internal class KafkaNewsProvider : INewsProvider, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly IConsumer<Ignore, NewsModel> _consumer;

        public KafkaNewsProvider(IConfiguration configuration, IConsumer<Ignore, NewsModel> consumer)
        {
            _configuration = configuration;
            _consumer = consumer;

            _consumer.Subscribe(_configuration.GetSection("NewsTopic").Value);
        }

        public void Dispose()
        {
            _consumer.Close();
        }

        public Task<NewsModel> GetNewsModelAsync()
        {
            return Task.FromResult(_consumer.Consume().Message.Value);
        }
    }
}
