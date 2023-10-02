using Gleeman.EffectiveLogger.MongoDB.Concretes;
using Gleeman.EffectiveLogger.MongoDB.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Gleeman.EffectiveLogger.MongoDB.Configurations;

public static class ServiceConfiguration
{
    public static LogSettings LogSettings { get; set; }

    static ServiceConfiguration()
    {
        LogSettings = new LogSettings();
    }

    public static IServiceCollection AddMongoDbLog(this IServiceCollection services, Action<LogSettings> settings)
    {
        settings.Invoke(LogSettings);
        services.AddServiceContainer();
        return services;
    }

    public static IServiceCollection AddEffectiveLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LogSettings>(configuration.GetSection(nameof(LogSettings)));
        services.AddServiceContainer();

        return services;
    }

    static IServiceCollection AddServiceContainer(this IServiceCollection services)
    {
        services.AddScoped<IMongoClient, MongoClient>();
        services.AddScoped<ILogEvent, LogEvent>();
        services.AddScoped<ILogFactory, LogFactory>();
        services.AddScoped<ILogging, Logging>();
        services.AddScoped(typeof(IEffectiveLogger<>), typeof(EffectiveLogger<>));
        return services;
    }
}
