using Marketplace.Models;

namespace Marketplace.UI.Core.Services.Interfaces
{
    public interface IUriBuilderService
    {
        public string BuildGetBoardGamesUri(string uri, ODataQueryParameters queryFiltersViewModel);

        public string AddDefaultBoardGamesQueryParameters(string uri);
    }
}