namespace Gleeman.EffectiveLogger.MongoDB.Concretes;

public class LogFactory : ILogFactory
{
    private AbstractLog instance { get; set; }
    public AbstractLog CreateLog(LogType logType)
    {
        return instance = logType switch
        {
            LogType.ConsoleLog => instance = new ConsoleLog(),
            LogType.FileLog => instance = new FileLog(),
            LogType.DatabaseLog => instance = new DatabaseLog(),
            _ => throw new NotImplementedException(),
        };
    }
}
