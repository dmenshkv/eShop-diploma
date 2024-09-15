namespace Catalog.Core.Services.Interfaces;

public interface IBoardGameService
{
    Task<BoardGameDto> CreateAsync(CreateBoardGameRequest request);

    Task<BoardGameDto> GetBySlugAsync(string slug);

    Task<IEnumerable<BoardGameDto>> GetAllAsync();

    Task<BoardGameDto> UpdateAsync(Guid id, UpdateBoardGameRequest request);

    Task DeleteAsync(Guid id);
}