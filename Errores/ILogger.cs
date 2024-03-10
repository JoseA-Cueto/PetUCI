using Microsoft.Extensions.Logging;

public interface ILogger
{
    void LogInformation(string message);
    void LogError(Exception ex, string message);
    // Agrega otros métodos según tus necesidades (LogWarning, LogDebug, etc.)
}