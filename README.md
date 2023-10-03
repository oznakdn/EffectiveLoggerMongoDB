# Gleeman.EffectiveLogger.MongoDB

| Package |  Version | Popularity |
| ------- | ----- | ----- |
| `Gleeman.EffectiveLogger.MongoDB` | [![NuGet](https://img.shields.io/nuget/v/Gleeman.EffectiveLogger.MongoDB.svg)](https://www.nuget.org/packages/Gleeman.EffectiveLogger.MongoDB) | [![Nuget](https://img.shields.io/nuget/dt/Gleeman.EffectiveLogger.MongoDB.svg)](https://www.nuget.org/packages/Gleeman.EffectiveLogger.MongoDB)

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
![Console](https://github.com/oznakdn/EffectiveLoggerMongoDB/assets/79724084/d30d22a0-49c8-4831-8b47-cbf67b18eb49)

### File
![File](https://github.com/oznakdn/EffectiveLoggerMongoDB/assets/79724084/51a4b6d0-ec33-4419-9ef5-fb72202dca09)

### Mongo
![MongoDB](https://github.com/oznakdn/EffectiveLoggerMongoDB/assets/79724084/72de875f-e1c1-48ee-9250-ee9106cb8dd8)




