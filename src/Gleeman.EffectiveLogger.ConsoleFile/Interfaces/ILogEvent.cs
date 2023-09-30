namespace Gleeman.EffectiveLogger.ConsoleFile.Interfaces;

public interface ILogEvent
{
    void LogHandler(EventHandler<string> handle, string message);
}
