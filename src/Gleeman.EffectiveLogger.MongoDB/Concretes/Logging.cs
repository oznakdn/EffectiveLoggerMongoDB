using Microsoft.Extensions.Options;

namespace Gleeman.EffectiveLogger.MongoDB.Concretes;

public class Logging : ILogging
{
    private readonly ILogEvent _logEvent;
    private readonly ILogFactory _logFactory;
    public Logging(ILogEvent logEvent, ILogFactory logFactory)
    {
        _logEvent = logEvent;
        _logFactory = logFactory;
    }

    public void LogWrite(LogLevelType levelType, string message)
    {
        LogSettings logOptions = ServiceConfiguration.LogSettings;

        if (logOptions.WriteToConsole == true)
        {
            var writeConsole = _logFactory.CreateLog(LogType.ConsoleLog);
            _logEvent.LogHandler((s, e) => writeConsole.Write(levelType, e), $"{levelType.ToString()}: {DateTime.Now} - {message}");
        }

        if (logOptions.WriteToFile == true && !string.IsNullOrEmpty(logOptions.FilePath))
        {

            var writeFile = _logFactory.CreateLog(LogType.FileLog);
            _logEvent.LogHandler((s, e) => writeFile.Write(logOptions.FilePath, logOptions.FileName, e), $"{levelType.ToString()}: {DateTime.Now} - {message}");
        }

        if (!string.IsNullOrEmpty(logOptions.MongoConnection) && !string.IsNullOrEmpty(logOptions.DatabaseName) && !string.IsNullOrEmpty(logOptions.CollectionName))
        {
            var writeDatabase = _logFactory.CreateLog(LogType.DatabaseLog);
            _logEvent.LogHandler((s, e) => writeDatabase.Write(levelType, e), $"{message}");
        }
    }
}
