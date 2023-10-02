using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Gleeman.EffectiveLogger.MongoDB;

public class Log
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string Id { get; set; }

    [BsonElement("logLevel")]
    public string LogLevel { get; set; }

    [BsonElement("date")]
    public DateTime LogDate { get; set; }

    [BsonElement("message")]
    public string Message { get; set; }
}
