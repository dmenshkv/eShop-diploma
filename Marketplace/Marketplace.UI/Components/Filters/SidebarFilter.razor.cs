using Marketplace.Models.Enums;
using Marketplace.Models.ViewModels.Filters;

namespace Marketplace.UI.Components.Filters;

public partial class SidebarFilter
{
    private ODataQueryParameters _queryParameters = new ODataQueryParameters();

    private Dictionary<string, bool> _categoryFilters = new Dictionary<string, bool>();

    private Dictionary<string, bool> _mechanicFilters = new Dictionary<string, bool>();

    private Dictionary<string, bool> _brandsFilter = new Dictionary<string, bool>();

    private string _sortCategory = null!;

    [Parameter]
    public EventCallback<ODataQueryParameters> OnFiltersChangedAsync { get; set; }

    [Parameter]
    public FilteringOptionsViewModel FilteringOptions { get; set; } = null!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        InitializeFilters(_brandsFilter, FilteringOptions.Brands);
        InitializeFilters(_categoryFilters, FilteringOptions.Categories);
        InitializeFilters(_mechanicFilters, FilteringOptions.Mechanics);
    }

    private void InitializeFilters(Dictionary<string, bool> filterDictionary, IEnumerable<string> options)
    {
        foreach (var option in options)
        {
            filterDictionary.Add(option, false);
        }
    }

    private async Task OnFiltersSelectedChangedAsync()
    {
        var brands = _brandsFilter.Where(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();
        var categories = _categoryFilters.Where(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();
        var mechanics = _mechanicFilters.Where(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();

        var filtersToApply = new List<(FilterCollectionModel Model, List<string> Values)>
        {
            (new FilterCollectionModel() { FilterTypeEnum = FilterTypeEnum.Brand, IsCollection = false }, brands),
            (new FilterCollectionModel() { FilterTypeEnum = FilterTypeEnum.Category, IsCollection = true }, categories),
            (new FilterCollectionModel() { FilterTypeEnum = FilterTypeEnum.Mechanic, IsCollection = true }, mechanics)
        };

        _queryParameters.Filters = new Dictionary<FilterCollectionModel, List<string>>();
        _queryParameters.OrderBy = _sortCategory ?? FilteringOptions.SortingCategories.First();

        foreach (var (model, values) in filtersToApply)
        {
            if (values.Any())
            {
                AddFilterToQuery(model, values);
            }
        }

        await OnFiltersChangedAsync.InvokeAsync(_queryParameters);
    }

    private void AddFilterToQuery(FilterCollectionModel filterModel, List<string> values)
    {
        _queryParameters.Filters!.Add(filterModel, values);
    }
}