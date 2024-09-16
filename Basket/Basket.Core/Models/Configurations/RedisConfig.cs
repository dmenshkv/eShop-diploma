namespace Basket.Core.Models.Configurations;

[ExcludeFromCodeCoverage]
public class RedisConfig
{
    public string Host { get; set; } = null!;

    public TimeSpan CacheTimeout { get; set; }
}