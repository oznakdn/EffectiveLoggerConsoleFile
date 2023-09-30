namespace Gleeman.EffectiveLogger.ConsoleFile.Abstracts;

public abstract class AbstractLog
{
    public virtual void Write(string message) { }
    public virtual void Write(string filePath, string fileName, string message) { }
    public virtual void Write(LogLevelType logLevelType, string message) { }
}
