namespace Gleeman.EffectiveLogger.ConsoleFile.Concretes;

public class LogFactory : ILogFactory
{
    private AbstractLog instance { get; set; }
    public AbstractLog CreateLog(LogType logType)
    {
        return instance = logType switch
        {
            LogType.ConsoleLog => instance = new ConsoleLog(),
            LogType.FileLog => instance = new FileLog(),
            _ => throw new NotImplementedException(),
        };
    }
}
