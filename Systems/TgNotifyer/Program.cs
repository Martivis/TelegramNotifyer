using Notifyer.Context;
using TgNotifyer;

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddAppDbContext(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
