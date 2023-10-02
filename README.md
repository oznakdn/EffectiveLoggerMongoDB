# Gleeman.EffectiveLogger.MongoDB


## Logging to MongoDB

#### Install packages
`dotnet` CLI
```
$ dotnet add package Gleeman.EffectiveLogger.MongoDB --version 2.0.0
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.MongoDB.Configurations;
```
```csharp
builder.Services.AddMongoDbLog(opt =>
{
    opt.WriteToConsole = true; // true or false
    opt.WriteToFile = true; //  true or false
    opt.FilePath = "File Path here";
    opt.FileName = "Api";
    opt.MongoConnection = "mongodb://localhost:27017";
    opt.CollectionName = "Logs";
    opt.DatabaseName = "ApiLog";
});
```
<hr>


### Controller
```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    private readonly IEffectiveLogger<WeatherForecastController> _logger;

    public WeatherForecastController(IEffectiveLogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.Info($"{Request.Path} - {Request.Method} - {Response.StatusCode}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
```
### Console
![Console](https://github.com/oznakdn/EffectiveLoggerMongoDB/assets/79724084/aba26e72-a21a-4e2d-b534-1d9561a6cdea)
### File
![File](https://github.com/oznakdn/EffectiveLoggerMongoDB/assets/79724084/37a28192-6b12-4bab-a520-4f57925ba9ac)
### Mongo
![MongoDB](https://github.com/oznakdn/EffectiveLoggerMongoDB/assets/79724084/5d8cd1f9-5073-40b6-bd0f-a1d6970c29e8)



