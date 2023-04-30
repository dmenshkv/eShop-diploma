using Microsoft.AspNetCore.Components;

namespace Marketplace.UI.Components.Header
{
    public partial class Header
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        private void HandleOnClick()
        {
            NavigationManager.NavigateTo("/basket");
        }
    }
}