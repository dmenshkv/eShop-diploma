using Basket.API.Extensions;
using Basket.Core.Constants;
using Basket.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.ConfigureRedis(configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddRedisRepositories();
builder.Services.AddCoreServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

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