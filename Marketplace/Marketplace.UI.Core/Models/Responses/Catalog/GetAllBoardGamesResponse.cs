using Marketplace.UI.Core.Models.ViewModels.Catalog;
using Newtonsoft.Json;

namespace Marketplace.UI.Core.Models.Responses.Catalog;

[ExcludeFromCodeCoverage]
public class GetAllBoardGamesResponse
{
    [JsonProperty("@odata.count")]
    public int Count { get; set; }

    [JsonProperty("value")]
    public IEnumerable<BoardGameViewModel> BoardGames { get; set; } = null!;
}