using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;

namespace Catalog.Core.Services.Interfaces
{
    public interface IBoardGameService
    {
        Task<AddItemResponse> AddBoardGameAsync(AddItemRequest<BoardGameDto> addItemRequest);

        Task<UpdateItemResponse> UpdateBoardGameAsync(Guid id, UpdateItemRequest<BoardGameDto> updateItemRequest);

        Task<RemoveItemResponse> RemoveBoardGameAsync(Guid id);

        Task<IEnumerable<BoardGameDto>> GetAllBoardGamesAsync();

        Task<GetBoardGameBySlugResponse> GetBoardGameBySlugAsync(string slug);
    }
}