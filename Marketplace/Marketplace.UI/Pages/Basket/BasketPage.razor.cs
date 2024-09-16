using Marketplace.UI.Core.Models.Requests.Basket;
using Marketplace.UI.Core.Models.ViewModels.Basket;

namespace Marketplace.UI.Pages.Basket;

public partial class BasketPage : PageComponentBase
{
    [Parameter]
    public CustomerBasketViewModel CustomerBasket { get; set; } = new CustomerBasketViewModel();

    [Inject]
    private IBasketService BasketService { get; set; } = default!;

    [Inject]
    private IOptions<AppSettings> AppSettings { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await InitializePageAsync();
    }

    protected override async Task InitializePageAsync()
    {
        await ExecuteSafelyAsync(async () =>
        {
            var response = await BasketService.GetBasketAsync(AppSettings.Value.UserId);

            CustomerBasket.Items = response.Items;
        });
    }

    private async Task HandleQuantityChangeAsync()
    {
        await UpdateBasketAsync();
    }

    private async Task HandleItemRemoveAsync(BasketItemViewModel item)
    {
        CustomerBasket.Items.Remove(item);

        await UpdateBasketAsync();
    }

    private async Task UpdateBasketAsync()
    {
        try
        {
            var userId = AppSettings.Value.UserId;
            var response = await BasketService.UpdateBasketAsync(userId, new UpdateBasketRequest()
            {
                CustomerId = userId,
                CustomerBasket = CustomerBasket
            });

            CustomerBasket = response;

            StateHasChanged();
        }
        catch (Exception)
        {
            Error?.ProcessError();
        }
    }

    private decimal CalculateTotalSingleItemPrice(decimal price, int quantity)
    {
        return Math.Round(price * quantity, 2);
    }
}