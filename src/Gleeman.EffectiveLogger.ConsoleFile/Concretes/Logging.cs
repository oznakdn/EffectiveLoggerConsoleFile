namespace Gleeman.EffectiveLogger.ConsoleFile.Concretes;

public class Logging : ILogging
{
    private readonly ILogEvent _logEvent;
    private readonly ILogFactory _logFactory;
    private readonly LogSettings _logSettings;
    public Logging(ILogEvent logEvent, ILogFactory logFactory)
    {
        _logEvent = logEvent;
        _logFactory = logFactory;
    }


    public Logging(IOptions<LogSettings> logSettings, ILogEvent logEvent, ILogFactory logFactory)
    {
        _logEvent = logEvent;
        _logFactory = logFactory;
        _logSettings = logSettings.Value;
    }

    public void LogWrite(LogLevelType levelType, string message)
    {
        LogSettings logOptions = ServiceConfiguration.LogSettings;

        if (logOptions.WriteToConsole == true || _logSettings.WriteToConsole == true)
        {
            var writeConsole = _logFactory.CreateLog(LogType.ConsoleLog);
            _logEvent.LogHandler((s, e) => writeConsole.Write(levelType, e), $"{levelType.ToString()}: {DateTime.Now} - {message}");
        }

        if (logOptions.WriteToFile == true || _logSettings.WriteToFile == true)
        {
            if (!string.IsNullOrEmpty(logOptions.FilePath))
            {
                var writeFile = _logFactory.CreateLog(LogType.FileLog);
                _logEvent.LogHandler((s, e) => writeFile.Write(logOptions.FilePath, logOptions.FileName, e), $"{levelType.ToString()}: {DateTime.Now} - {message}");
            }

            if (!string.IsNullOrEmpty(_logSettings.FilePath))
            {
                var writeFile = _logFactory.CreateLog(LogType.FileLog);
                _logEvent.LogHandler((s, e) => writeFile.Write(_logSettings.FilePath, _logSettings.FileName, e), $"{levelType.ToString()}: {DateTime.Now} - {message}");
            }
        }
    }
}
