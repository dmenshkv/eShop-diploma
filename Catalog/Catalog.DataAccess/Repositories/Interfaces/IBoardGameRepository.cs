namespace Catalog.DataAccess.Repositories.Interfaces;

public interface IBoardGameRepository
{
    Task<BoardGame> CreateAsync(BoardGame boardGame);

    Task<BoardGame> UpdateAsync(Guid id, BoardGame boardGame);

    Task<IReadOnlyList<BoardGame>> GetAllAsync();

    Task<BoardGame> GetBySlugAsync(string slug);
}