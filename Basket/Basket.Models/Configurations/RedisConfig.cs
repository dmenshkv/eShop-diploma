using System.Diagnostics.CodeAnalysis;

namespace Basket.Models.Configurations
{
    [ExcludeFromCodeCoverage]
    public class RedisConfig
    {
        public string Host { get; set; } = null!;

        public TimeSpan CacheTimeout { get; set; }
    }
}