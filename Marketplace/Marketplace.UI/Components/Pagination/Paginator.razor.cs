using Marketplace.Models;
using Microsoft.AspNetCore.Components;

namespace Marketplace.UI.Components.Pagination
{
    public partial class Paginator
    {
        [Parameter]
        public PaginationModel Pagination { get; set; } = null!;

        [Parameter]
        public EventCallback<int> OnCurrentPageChangedAsync { get; set; }

        private int _totalPages => (int)Math.Ceiling(Pagination.TotalItemsCount / (double)Pagination.PageSize);

        private async Task OnPageChangedAsync(int pageNumber)
        {
            Pagination.CurrentPage = pageNumber;
            await OnCurrentPageChangedAsync.InvokeAsync(Pagination.CurrentPage);
        }
    }
}