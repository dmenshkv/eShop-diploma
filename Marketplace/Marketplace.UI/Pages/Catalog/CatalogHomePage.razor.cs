using Marketplace.Models.Constants;
using Marketplace.Models.ViewModels.Catalog;
using Marketplace.Models.ViewModels.Filters;

namespace Marketplace.UI.Pages.Catalog;

public partial class CatalogHomePage : PageComponentBase
{
    private PaginationModel _pagination = null!;

    private int _pageNumber = 1;

    private int _pageSize;

    private FilteringOptionsViewModel _filteringOptions = null!;

    private ODataQueryParameters _queryParameters = new ODataQueryParameters()
    {
        OrderBy = SortingCategoriesConstants.PriceAscending
    };

    [Parameter]
    public IEnumerable<BoardGameViewModel> Items { get; set; } = null!;

    protected bool AreThereItems { get; set; }

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

            _filteringOptions = await getFilteringOptionsTask;

            await loadPageTask;
        });
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

        var items = await BoardGameService.GetAllAsync(_queryParameters);

        AreThereItems = items.Count > 0;

        Items = items.BoardGames;

        _pagination = new PaginationModel()
        {
            CurrentPage = _pageNumber,
            PageSize = _pageSize,
            TotalItemsCount = items.Count
        };

        StateHasChanged();
    }

    private void ChangePage()
    {
        _queryParameters.Skip = (_pageNumber - 1) * _pageSize;
        _queryParameters.Top = _pageSize;
    }

    private async Task<FilteringOptionsViewModel> GetFilteringOptions()
    {
        var getAllBrandsTask = BrandService.GetAllAsync();
        var getAllCategoriesTask = CategoryService.GetAllAsync();
        var getAllMechanicsTask = MechanicService.GetAllAsync();

        await Task.WhenAll(getAllBrandsTask, getAllCategoriesTask, getAllMechanicsTask);

        var brands = await getAllBrandsTask;
        var categories = await getAllCategoriesTask;
        var mechanics = await getAllMechanicsTask;

        return new FilteringOptionsViewModel()
        {
            Brands = brands.Value.Select(b => b.Name).ToList(),
            SortingCategories = new List<string>()
            {
                SortingCategoriesConstants.PriceAscending,
                SortingCategoriesConstants.PriceDescending,
            },
            Categories = categories.Value.Select(c => c.Name).ToList(),
            Mechanics = mechanics.Value.Select(m => m.Name).ToList()
        };
    }
}