namespace Marketplace.UI.Core.Services.Interfaces;

public interface IBoardGameService
{
    Task<AddItemResponse> AddBoardGameAsync(AddItemRequest<BoardGameViewModel> addItemRequest);

    Task<UpdateItemResponse> UpdateBoardGameAsync(Guid id, UpdateItemRequest<BoardGameViewModel> updateItemRequest);

    Task<RemoveItemResponse> RemoveBoardGameAsync(Guid id);

    Task<GetAllBoardGamesResponse> GetAllBoardGamesAsync(ODataQueryParameters? queryParameters = null);

    Task<GetBoardGameBySlugResponse> GetBoardGameBySlugAsync(string slug);
}