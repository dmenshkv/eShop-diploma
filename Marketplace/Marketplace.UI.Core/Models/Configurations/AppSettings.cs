namespace Marketplace.UI.Core.Models.Configurations;

[ExcludeFromCodeCoverage]
public class AppSettings
{
    public string CatalogUrl { get; set; } = null!;

    public string BasketUrl { get; set; } = null!;

    public PaginationSettings Pagination { get; set; } = null!;

    public Guid UserId { get; set; }

    public int RequestTimeoutInMinutes { get; set; }
}