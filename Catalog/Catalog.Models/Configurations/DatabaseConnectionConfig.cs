using System.Diagnostics.CodeAnalysis;

namespace Catalog.Models.Configurations
{
    [ExcludeFromCodeCoverage]
    public class DatabaseConnectionConfig
    {
        public string ConnectionString { get; set; } = null!;
    }
}