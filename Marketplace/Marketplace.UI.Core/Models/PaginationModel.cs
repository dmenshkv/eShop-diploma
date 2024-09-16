namespace Marketplace.UI.Core.Models;

[ExcludeFromCodeCoverage]
public class PaginationModel
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalItemsCount { get; set; }
}