namespace Gleeman.EffectiveLogger.MongoDB.Interfaces;

public interface ILogEvent
{
    void LogHandler(EventHandler<string> handle, string message);
}
