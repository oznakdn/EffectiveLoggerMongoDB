using Gleeman.EffectiveLogger.MongoDB.Abstracts;
using Gleeman.EffectiveLogger.MongoDB.Enumerations;

namespace Gleeman.EffectiveLogger.MongoDB.Interfaces;

public interface ILogFactory
{
    AbstractLog CreateLog(LogType logType);
}
