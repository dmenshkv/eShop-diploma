using Basket.API.Constants;
using Basket.API.Extensions;
using Basket.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var redisConfigurationSection = configuration.GetSection(ConfigurationSectionsNames.Redis);

builder.Services.ConfigureRedis(redisConfigurationSection);
builder.Services.AddInfrastructureServices();
builder.Services.AddRedisRepositories();
builder.Services.AddCoreServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCorsForOrigins(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ConfigurationSectionsNames.CorsOrigin);

app.UseAuthorization();

app.UseErrorHandlingMiddleware();
app.MapControllers();

await app.RunAsync();
