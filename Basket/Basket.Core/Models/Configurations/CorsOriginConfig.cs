namespace Basket.Core.Models.Configurations;

[ExcludeFromCodeCoverage]
public class CorsOriginConfig
{
    public IEnumerable<string> AllowedOrigins { get; set; } = null!;
}