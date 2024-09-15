using System.Diagnostics.CodeAnalysis;
using Marketplace.Models.ViewModels.Catalog;
using Newtonsoft.Json;

namespace Marketplace.Models.Responses;

[ExcludeFromCodeCoverage]
public class GetAllBoardGamesResponse
{
    [JsonProperty("@odata.count")]
    public int Count { get; set; }

    [JsonProperty("value")]
    public IEnumerable<BoardGameViewModel> BoardGames { get; set; } = null!;
}