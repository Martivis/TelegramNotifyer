using Notifyer.Data.Context;
using Notifyer.Systems.TgNotifyer;
using Notifyer.Services.KafkaDataProvider;
using Notifyer.Services.Notifications;
using Notifyer.Services.TelegramService;
using Notifyer.Services.Subscriptions;

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddKafkaNewsProvider(configuration);
        services.AddNotificationService();
        services.AddSubscriptionsService();
        services.AddTelegramService();
        services.AddAppDbContext(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

AppDbInitializer.Execute(host.Services);
AddDbSeeder.Seed(host.Services);

host.Run();
