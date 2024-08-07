using Marketplace.Models.Requests.Basket;
using Marketplace.Models.Responses;
using Marketplace.Models.ViewModels;
using Marketplace.Models.ViewModels.Basket;

namespace Marketplace.UI.Pages.Catalog.BoardGame;

public partial class BoardGameDetailsPage : PageComponentBase
{
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

    private const string BoardGameRoute = "board-games/{slug}";

    private BoardGameViewModel _boardGame = null!;

    private int _quantity = 1;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await InitializePageAsync();
    }

    protected override async Task InitializePageAsync()
    {
        await ExecuteSafelyAsync(async() =>
        {
            var uri = GetCurrentPagePath();
            var response = await HttpClientService.GetAsync<GetBoardGameBySlugResponse>(uri);

            _boardGame = response.BoardGame;
        });
    }

    private async Task AddToBasket()
    {
        try
        {
            await BasketService.AddToBasketAsync(new AddToBasketRequest()
            {
                Id = AppSettings.Value.UserId,
                Item = new BasketItemViewModel()
                {
                    Id = _boardGame.Id,
                    Name = _boardGame.Name,
                    PictureUrl = _boardGame.PictureUrl,
                    Price = _boardGame.Price,
                    Quantity = _quantity
                }
            });
        }
        catch (NullReferenceException)
        {
            Error?.ProcessError();
        }
    }

    private string GetCurrentPagePath()
    {
        return $"{AppSettings.Value.CatalogUrl}/{NavigationManager.ToBaseRelativePath(NavigationManager.Uri)}";
    }
}