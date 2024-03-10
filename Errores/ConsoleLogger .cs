public class ConsoleLogger : ILogger
{
    private readonly Microsoft.Extensions.Logging.ILogger _logger;

    public ConsoleLogger(ILogger<ConsoleLogger> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogError(Exception ex, string message)
    {
        _logger.LogError(ex, message);
    }

}