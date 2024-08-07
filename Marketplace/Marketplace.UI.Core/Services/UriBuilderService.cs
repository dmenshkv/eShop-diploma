using System.Text;
using Marketplace.Models.Constants;
using Microsoft.AspNetCore.WebUtilities;

namespace Marketplace.UI.Core.Services;

public class UriBuilderService : IUriBuilderService
{
    public string BuildGetBoardGamesUri(string uri, ODataQueryParameters queryParametersViewModel)
    {
        var areFiltersExists = queryParametersViewModel.Filters != null
            && queryParametersViewModel.Filters.Count > 0;

        if (areFiltersExists)
        {
            uri = AddQueryFilters(uri, "filter", queryParametersViewModel.Filters!);
        }

        if (queryParametersViewModel.OrderBy != null)
        {
            uri = AddQueryParameter(uri, "orderby", queryParametersViewModel.OrderBy!);
        }

        if (queryParametersViewModel.Skip.HasValue)
        {
            uri = AddQueryParameter(uri, "skip", queryParametersViewModel.Skip.ToString()!);
        }

        if (queryParametersViewModel.Top.HasValue)
        {
            uri = AddQueryParameter(uri, "top", queryParametersViewModel.Top.ToString()!);
        }

        uri = AddDefaultBoardGamesQueryParameters(uri);

        return Uri.UnescapeDataString(uri);
    }

    public string AddDefaultBoardGamesQueryParameters(string uri)
    {
        uri = AddQueryParameter(uri, "count", "true");

        return Uri.UnescapeDataString(uri);
    }

    private string AddQueryFilters(string uri, string name, Dictionary<FilterCollectionModel, List<string>> filters)
    {
        var fullQueryFilter = new StringBuilder();
        var totalFiltersCount = filters.Count;

        if (totalFiltersCount == 1)
        {
            fullQueryFilter.Append(AddSingleQueryFilter(filters.First()));
        }
        else if (totalFiltersCount > 1)
        {
            fullQueryFilter.Append(AddSingleQueryFilter(filters.First()));
            var filtersWithoutFirst = filters.Skip(1);

            foreach (var filter in filtersWithoutFirst)
            {
                fullQueryFilter.Append(" and ");
                fullQueryFilter.Append(AddSingleQueryFilter(filter));
            }
        }

        return AddQueryParameter(uri, name, fullQueryFilter.ToString());
    }

    private string AddSingleQueryFilter(KeyValuePair<FilterCollectionModel, List<string>> filter)
    {
        var filterStart = filter.Key.IsCollection
            ? string.Format(
                ODataQueryConstants.CollectionFilterStart,
                ODataQueryConstants.CategoryFilters[filter.Key.FilterTypeEnum.ToString()],
                filter.Key.FilterTypeEnum.ToString()) : ODataQueryConstants.GroupStartSymbol;

        var queryFilter = new StringBuilder(filterStart);

        queryFilter.Append(string.Format(
            ODataQueryConstants.FilterByName,
            filter.Key.FilterTypeEnum.ToString(),
            filter.Value[0]));

        var totalFiltersCount = filter.Value.Count;

        if (totalFiltersCount > 1)
        {
            for (var i = 1; i < totalFiltersCount; i++)
            {
                var filterValue = string.Format(
                    ODataQueryConstants.FilterByName,
                    filter.Key.FilterTypeEnum.ToString(),
                    filter.Value[i]);

                queryFilter.Append($" or {filterValue}");
            }
        }

        queryFilter.Append(ODataQueryConstants.GroupEndSymbol);

        return queryFilter.ToString();
    }

    private string AddQueryParameter(string uri, string name, string value)
    {
        return QueryHelpers.AddQueryString(uri, name, value);
    }
}