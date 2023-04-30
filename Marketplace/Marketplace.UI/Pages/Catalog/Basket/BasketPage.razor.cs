using Marketplace.Models.Configurations;
using Marketplace.Models.ViewModels.Basket;
using Marketplace.UI.Core.Services.Interfaces;
using Marketplace.UI.Pages.BasePages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Pages.Catalog.Basket
{
    public partial class BasketPage : PageComponentBase
    {
        [Parameter]
        public CustomerBasketViewModel CustomerBasket { get; set; } = new CustomerBasketViewModel();

        [Inject]
        private IBasketService BasketService { get; set; } = default!;

        [Inject]
        private IOptions<AppSettings> AppSettings { get; set; } = default!;

        private const string BasketRoute = "basket";

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

        private async Task HandleItemRemoveAsync(Guid itemId)
        {
            try
            {
                var response = await BasketService.RemoveFromBasket(AppSettings.Value.UserId, itemId);

                if (response.IsRemoved)
                {
                    var updatedBasketResponse = await BasketService.GetBasketAsync(AppSettings.Value.UserId);

                    CustomerBasket.Items = updatedBasketResponse.Items;

                    StateHasChanged();
                }
            }
            catch (NullReferenceException)
            {
                Error?.ProcessError();
            }
        }
    }
}
