namespace Gleeman.EffectiveLogger.MongoDB.Concretes;

public class EffectiveLogger<T> : IEffectiveLogger<T>
    where T : class
{
    private readonly ILogging _logging;
    public EffectiveLogger(ILogging logging)
    {
        _logging = logging;
    }

    public void Debug(string message)
    {
        _logging.LogWrite(LogLevelType.dbug, message);
    }

    public void Fail(string message)
    {
        _logging.LogWrite(LogLevelType.fail, message);

    }

    public void Info(string message)
    {
        _logging.LogWrite(LogLevelType.info, message);

    }

    public void Warning(string message)
    {
        _logging.LogWrite(LogLevelType.warn, message);
    }
}
