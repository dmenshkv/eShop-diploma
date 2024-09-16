namespace Catalog.Core.Models.Configurations;

[ExcludeFromCodeCoverage]
public class CorsOriginConfig
{
    public List<string> AllowedOrigins { get; set; } = null!;
}