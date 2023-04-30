using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Configurations
{
    [ExcludeFromCodeCoverage]
    public class CorsOriginConfig
    {
        public List<string> AllowedOrigins { get; set; } = null!;
    }
}