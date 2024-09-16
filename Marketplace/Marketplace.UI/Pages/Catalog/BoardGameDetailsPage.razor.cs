using Marketplace.UI.Core.Constants;
using Marketplace.UI.Core.Models.Requests.Basket;
using Marketplace.UI.Core.Models.ViewModels.Basket;
using Marketplace.UI.Core.Models.ViewModels.Catalog;

namespace Marketplace.UI.Pages.Catalog;

public partial class BoardGameDetailsPage : PageComponentBase
{
    private BoardGameViewModel _boardGame = null!;

    private bool _isItemAdded = false;

    private int _quantity = 1;

    [Parameter]
    public string Slug { get; set; } = null!;

    [Inject]
    private IHttpClientService HttpClientService { get; set; } = null!;

    [Inject]
    private IBasketService BasketService { get; set; } = null!;

    [Inject]
    private IOptions<AppSettings> AppSettings { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await InitializePageAsync();
    }

    protected override async Task InitializePageAsync()
    {
        await ExecuteSafelyAsync(async () =>
        {
            var uri = GetCurrentPagePath();
            var response = await HttpClientService.GetAsync<BoardGameViewModel>(uri);

            _boardGame = response;
        });
    }

    private async Task AddToBasketAsync()
    {
        try
        {
            var result = await BasketService.AddBasketItemAsync(new AddItemRequest()
            {
                CustomerId = AppSettings.Value.UserId,
                Item = new BasketItemViewModel()
                {
                    Id = _boardGame.Id,
                    Name = _boardGame.Name,
                    PictureUrl = _boardGame.PictureUrl,
                    Price = _boardGame.Price,
                    Quantity = _quantity
                }
            });

            if (result.IsItemAdded)
            {
                _isItemAdded = true;

                StateHasChanged();

                await Task.Delay(2000);

                _isItemAdded = false;
            }
        }
        catch (Exception)
        {
            Error?.ProcessError();
        }
    }

    private string GetCurrentPagePath()
    {
        return string.Format(ApiRouteTemplates.ApiFormat, AppSettings.Value.CatalogUrl, NavigationManager.ToBaseRelativePath(NavigationManager.Uri));
        // return $"{AppSettings.Value.CatalogUrl}/api/{NavigationManager.ToBaseRelativePath(NavigationManager.Uri)}";
    }
}