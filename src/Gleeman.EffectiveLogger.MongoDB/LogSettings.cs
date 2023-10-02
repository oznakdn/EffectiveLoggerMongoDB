namespace Gleeman.EffectiveLogger.MongoDB;

public class LogSettings
{
    public bool WriteToConsole { get; set; } = false;
    public bool WriteToFile { get; set; } = false;
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string MongoConnection { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }

}
