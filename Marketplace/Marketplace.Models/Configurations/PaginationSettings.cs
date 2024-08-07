using System.Diagnostics.CodeAnalysis;

namespace Marketplace.Models.Configurations;

[ExcludeFromCodeCoverage]
public class PaginationSettings
{
    public int PageSize { get; set; }
}