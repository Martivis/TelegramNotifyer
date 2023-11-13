using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifyer.Services.KafkaDataSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataSender
{
    public static class Bootstraper
    {
        public static IServiceCollection AddKafkaNewsSender(this IServiceCollection services, IConfiguration configuration)
        {
            var kafkaConfig = new ProducerConfig
            {
                BootstrapServers = configuration.GetSection("KafkaHost").Value
            };
            
            var producer = new ProducerBuilder<Ignore, NewsModel>(kafkaConfig).Build();
            services.AddSingleton(producer);
            services.AddSingleton<INewsSender, KafkaNewsSender>();
            
            return services;
        }

        public static IServiceCollection AddMockNewsProvider(this IServiceCollection services)
        {
            services.AddSingleton<INewsProvider, MockNewsProvider>();
            return services;
        }
    }
}
