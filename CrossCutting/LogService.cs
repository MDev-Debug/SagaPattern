using Domain.Interface;
using Serilog;

namespace CrossCutting;

public class LogService : ILogService
{
    public void LogInfo(string message)
    {
        Log.Information(message);
    }

    public void LogError(string message, Exception ex)
    {
        Log.Error(ex, message);
    }
}