using Marketplace.Models;
using Marketplace.Models.Enums;
using Marketplace.Models.ViewModels.Filters;
using Microsoft.AspNetCore.Components;

namespace Marketplace.UI.Components.Filters
{
    public partial class SidebarFilter
    {
        [Parameter]
        public EventCallback<ODataQueryParameters> OnFiltersChangedAsync { get; set; }

        [Parameter]
        public FilteringOptionsViewModel FilteringOptions { get; set; } = null!;

        private ODataQueryParameters _queryParameters = new ODataQueryParameters();

        private Dictionary<string, bool> _categoryFilters = new Dictionary<string, bool>();

        private Dictionary<string, bool> _mechanicFilters = new Dictionary<string, bool>();

        private Dictionary<string, bool> _brandsFilter = new Dictionary<string, bool>();

        private string _sortCategory = null!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            foreach (var brand in FilteringOptions.Brands)
            {
                _brandsFilter.Add(brand, false);
            }

            foreach (var category in FilteringOptions.Categories)
            {
                _categoryFilters.Add(category, false);
            }

            foreach (var mechanic in FilteringOptions.Mechanics)
            {
                _mechanicFilters.Add(mechanic, false);
            }
        }

        private async Task OnFiltersSelectedChangedAsync()
        {
            var brands = _brandsFilter.Where(w => w.Value).Select(s => s.Key).ToList();
            var categories = _categoryFilters.Where(w => w.Value).Select(s => s.Key).ToList();
            var mechanics = _mechanicFilters.Where(w => w.Value).Select(s => s.Key).ToList();

            var brandsFiltersApplied = brands.Count > 0;
            var categoriesFiltersApplied = categories.Count > 0;
            var mechanicsFiltersApplied = mechanics.Count > 0;

            _queryParameters.Filters = new Dictionary<FilterCollectionModel, List<string>>();
            _queryParameters.OrderBy = _sortCategory ?? FilteringOptions.SortingCategories.First();

            if (brandsFiltersApplied || categoriesFiltersApplied || mechanicsFiltersApplied)
            {
                if (brandsFiltersApplied)
                {
                    AddFilterToQuery(
                        new FilterCollectionModel() { FilterTypeEnum = FilterTypeEnum.Brand, IsCollection = false },
                        _brandsFilter.Where(w => w.Value).Select(s => s.Key).ToList());
                }

                if (categoriesFiltersApplied)
                {
                    AddFilterToQuery(
                        new FilterCollectionModel() { FilterTypeEnum = FilterTypeEnum.Category, IsCollection = true },
                        _categoryFilters.Where(w => w.Value).Select(s => s.Key).ToList());
                }

                if (mechanicsFiltersApplied)
                {
                    AddFilterToQuery(
                        new FilterCollectionModel() { FilterTypeEnum = FilterTypeEnum.Mechanic, IsCollection = true },
                        _mechanicFilters.Where(w => w.Value).Select(s => s.Key).ToList());
                }
            }

            await OnFiltersChangedAsync.InvokeAsync(_queryParameters);
        }

        private void AddFilterToQuery(FilterCollectionModel filterModel, List<string> values)
        {
            _queryParameters.Filters!.Add(filterModel, values);
        }
    }
}