using Marketplace.UI.Core.Models.ViewModels.Catalog;

namespace Marketplace.UI.Components.Item;

public partial class Item
{
    private const string BoardGameFormat = "board-game/{0}";

    [Parameter]
    public BoardGameViewModel BoardGame { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private string _path => string.Format(BoardGameFormat, BoardGame.Slug);

    private void NavigateToItem()
    {
        NavigationManager.NavigateTo(_path);
    }
}