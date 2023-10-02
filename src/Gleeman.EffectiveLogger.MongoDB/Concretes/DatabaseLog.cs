namespace Gleeman.EffectiveLogger.MongoDB.Concretes;

internal class DatabaseLog : AbstractLog
{
    private readonly IMongoCollection<Log> _collection;
    private readonly IMongoClient _mongoClient;
    public DatabaseLog()
    {
        LogSettings logOptions = ServiceConfiguration.LogSettings;
        _mongoClient = new MongoClient(logOptions.MongoConnection);
        IMongoDatabase database = _mongoClient.GetDatabase(logOptions.DatabaseName);
        _collection = database.GetCollection<Log>(logOptions.CollectionName);
    }

    public override void Write(LogLevelType logLevelType, string message)
    {
        _collection.InsertOne(new Log
        {
            LogDate = DateTime.UtcNow,
            LogLevel = logLevelType.ToString(),
            Message = message
        });
    }
}
