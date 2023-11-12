using Microsoft.Extensions.Hosting;

public sealed class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    readonly SmtpServer.SmtpServer _smtpServer;

    public Worker(ILogger<Worker> logger, SmtpServer.SmtpServer smtpServer)
    {
        _logger = logger;
        _smtpServer = smtpServer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
          _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        return _smtpServer.StartAsync(stoppingToken);
    }
}
