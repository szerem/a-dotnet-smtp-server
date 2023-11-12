using SmtpServer;
using SmtpServer.Storage;


var builder = Host.CreateApplicationBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMessageStore, ConsoleMessageStore>();
builder.Services.AddSingleton(
    provider =>
    {
        var options = new SmtpServerOptionsBuilder()
            .ServerName("SMTP Server")
            .Port(25552)
            .Build();

        return new SmtpServer.SmtpServer(options, provider.GetRequiredService<IServiceProvider>());
    }
);

builder.Services.AddHostedService<Worker>();
IHost host = builder.Build();
host.Run();

