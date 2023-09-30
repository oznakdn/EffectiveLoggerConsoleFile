namespace Gleeman.EffectiveLogger.ConsoleFile;

public class LogSettings
{
    public bool WriteToConsole { get; set; } = false;
    public bool WriteToFile { get; set; } = false;
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
