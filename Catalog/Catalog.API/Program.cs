using Catalog.API.Extensions;
using Catalog.Core.Extensions;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext(configuration);
builder.Services.AddRepositories();
builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices();
builder.Services.ConfigureOptions(configuration);

builder.Services.AddControllers().AddOData(options => options.SetupODataOptions(configuration));
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
app.UseODataRouteDebug();
app.MapControllers();

await app.InitializeDatabaseAsync();

await app.RunAsync();