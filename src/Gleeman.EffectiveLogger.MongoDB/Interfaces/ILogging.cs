using Gleeman.EffectiveLogger.MongoDB.Enumerations;

namespace Gleeman.EffectiveLogger.MongoDB.Interfaces;

public interface ILogging
{
    void LogWrite(LogLevelType levelType, string message);
}
