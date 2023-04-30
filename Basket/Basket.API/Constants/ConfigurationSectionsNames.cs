using System.Diagnostics.CodeAnalysis;

namespace Basket.API.Constants
{
    [ExcludeFromCodeCoverage]
    public static class ConfigurationSectionsNames
    {
        public const string CorsOrigin = nameof(CorsOrigin);

        public const string Redis = nameof(Redis);
    }
}
