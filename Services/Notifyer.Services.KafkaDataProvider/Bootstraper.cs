using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifyer.Services.KafkaDataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataProvider
{
    public static class Bootstraper
    {
        public static IServiceCollection AddMockNewsProvider(this IServiceCollection services)
        {
            services.AddSingleton<INewsProvider, MockNewsProvider>();
            return services;
        }

        public static IServiceCollection AddKafkaNewsProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var kafkaConfig = new ConsumerConfig
            {
                BootstrapServers = configuration.GetSection("KafkaHost").Value,
                GroupId = "News",
                EnableAutoCommit = true
            };
            var consumer = new ConsumerBuilder<Ignore, string>(kafkaConfig).Build();

            services.AddSingleton(consumer);
            services.AddSingleton<INewsProvider, KafkaNewsProvider>();

            return services;
        }
    }
}
