namespace Gleeman.EffectiveLogger.ConsoleFile.Interfaces;

public interface IEffectiveLogger<T> where T : class
{
    void Debug(string message);
    void Info(string message);
    void Warning(string message);
    void Fail(string message);
}
