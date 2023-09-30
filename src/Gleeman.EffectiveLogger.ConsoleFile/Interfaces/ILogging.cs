namespace Gleeman.EffectiveLogger.ConsoleFile.Interfaces;

public interface ILogging
{
    void LogWrite(LogLevelType levelType, string message);
}
