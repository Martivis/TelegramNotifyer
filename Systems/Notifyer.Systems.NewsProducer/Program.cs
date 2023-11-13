using Notifyer.Services.KafkaDataSender;

namespace Notifyer.Systems.NewsProducer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddKafkaNewsSender(configuration);
                    services.AddMockNewsProvider();
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}