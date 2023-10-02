namespace Gleeman.EffectiveLogger.MongoDB.Concretes;
public class LogEvent : ILogEvent
{
    public void LogHandler(EventHandler<string> handle, string message) => handle?.Invoke(this, message);

}
