namespace Gleeman.EffectiveLogger.ConsoleFile.Interfaces;

public interface ILogFactory
{
    AbstractLog CreateLog(LogType logType);
}
