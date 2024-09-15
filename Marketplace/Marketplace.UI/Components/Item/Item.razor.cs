using Marketplace.Models.ViewModels.Catalog;
using Marketplace.UI.Constants;

namespace Marketplace.UI.Components.Item;

public partial class Item
{
    [Parameter]
    public BoardGameViewModel BoardGame { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private string _path => string.Format(RouteFormats.BoardGameFormat, BoardGame.Slug);

    private void NavigateToItem()
    {
        NavigationManager.NavigateTo(_path);
    }
}