using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Configurations
{
    [ExcludeFromCodeCoverage]
    public class CorsOriginConfig
    {
        public IEnumerable<string> AllowedOrigins { get; set; } = null!;
    }
}