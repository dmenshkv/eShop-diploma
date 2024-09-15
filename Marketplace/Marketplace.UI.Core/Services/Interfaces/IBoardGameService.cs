using Marketplace.Models.Requests.Catalog;
using Marketplace.Models.ViewModels.Catalog;

namespace Marketplace.UI.Core.Services.Interfaces;

public interface IBoardGameService
{
    Task<BoardGameViewModel> CreateAsync(CreateBoardGameRequest request);

    Task<BoardGameViewModel> GetBySlugAsync(string slug);

    Task<GetAllBoardGamesResponse> GetAllAsync(ODataQueryParameters? queryParameters = null);

    Task<BoardGameViewModel> UpdateAsync(Guid id, UpdateBoardGameRequest request);

    Task DeleteAsync(Guid id);
}