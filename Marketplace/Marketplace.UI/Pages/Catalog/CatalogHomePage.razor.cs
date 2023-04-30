using Marketplace.Models;
using Marketplace.Models.Configurations;
using Marketplace.Models.Constants;
using Marketplace.Models.ViewModels;
using Marketplace.Models.ViewModels.Filters;
using Marketplace.UI.Core.Services.Interfaces;
using Marketplace.UI.Pages.BasePages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Pages.Catalog
{
    public partial class CatalogHomePage : PageComponentBase
    {
        [Parameter]
        public IEnumerable<BoardGameViewModel> Items { get; set; } = null!;

        [Inject]
        private IOptions<AppSettings> AppSettings { get; set; } = default!;

        [Inject]
        private IBoardGameService BoardGameService { get; set; } = null!;

        [Inject]
        private IBrandService BrandService { get; set; } = null!;

        [Inject]
        private ICategoryService CategoryService { get; set; } = null!;

        [Inject]
        private IMechanicService MechanicService { get; set; } = null!;

        private const string HomePageRoute = "/";

        protected bool IsNextPageLoading { get; set; }

        private PaginationModel _pagination = null!;

        private int _pageNumber = 1;

        private int _pageSize;

        private FilteringOptionsViewModel _filteringOptions = null!;

        private ODataQueryParameters _queryParameters = new ODataQueryParameters()
        {
            OrderBy = SortingCategoriesConstants.PriceAscending
        };

        protected override async Task OnInitializedAsync()
        {
            _pageSize = AppSettings.Value.Pagination.PageSize;

            await base.OnInitializedAsync();

            await InitializePageAsync();
        }

        protected override async Task InitializePageAsync()
        {
            await ExecuteSafelyAsync(async () =>
            {
                var loadPageTask = LoadPageAsync();
                var getFilteringOptionsTask = GetFilteringOptions();

                await Task.WhenAll(loadPageTask, getFilteringOptionsTask);

                _filteringOptions = await getFilteringOptionsTask;
                await loadPageTask;
            });
        }

        private async Task<FilteringOptionsViewModel> GetFilteringOptions()
        {
            var getAllBrandsTask = BrandService.GetAllBrandsAsync();
            var getAllCategoriesTask = CategoryService.GetAllCategoriesAsync();
            var getAllMechanicsTask = MechanicService.GetAllMechanicsAsync();

            await Task.WhenAll(getAllBrandsTask, getAllCategoriesTask, getAllMechanicsTask);

            var brands = await getAllBrandsTask;
            var categories = await getAllCategoriesTask;
            var mechanics = await getAllMechanicsTask;

            return new FilteringOptionsViewModel()
            {
                Brands = brands.Value.Select(s => s.Name).ToList(),
                SortingCategories = new List<string>()
                {
                    SortingCategoriesConstants.PriceAscending,
                    SortingCategoriesConstants.PriceDescending,
                },
                Categories = categories.Value.Select(s => s.Name).ToList(),
                Mechanics = mechanics.Value.Select(s => s.Name).ToList()
            };
        }

        private async Task OnFiltersChangedAsync(ODataQueryParameters queryParameters)
        {
            await LoadPageAsync(queryParameters);
        }

        private async Task OnCurrentPageChangedAsync(int pageNumber)
        {
            _pageNumber = pageNumber;
            await LoadPageAsync();
        }

        private async Task LoadPageAsync(ODataQueryParameters? queryParameters = null)
        {
            if (queryParameters != null)
            {
                _queryParameters = queryParameters;
            }

            ChangePage();

            var items = await BoardGameService.GetAllBoardGamesAsync(_queryParameters);

            Items = items.BoardGames;
            _pagination = new PaginationModel()
            {
                CurrentPage = _pageNumber,
                PageSize = _pageSize,
                TotalItemsCount = items.Count
            };
        }

        private void ChangePage()
        {
            _queryParameters.Skip = (_pageNumber - 1) * _pageSize;
            _queryParameters.Top = _pageSize;
        }
    }
}