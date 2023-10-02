using Gleeman.EffectiveLogger.MongoDB.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMongoDbLog(opt =>
{
    opt.WriteToConsole = true;
    opt.WriteToFile = true;
    opt.FilePath = "File Path here";
    opt.FileName = "Api";
    opt.MongoConnection = "mongodb://localhost:27017";
    opt.CollectionName = "Logs";
    opt.DatabaseName = "ApiLog";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
