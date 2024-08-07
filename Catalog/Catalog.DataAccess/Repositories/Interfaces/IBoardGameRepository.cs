namespace Catalog.DataAccess.Repositories.Interfaces;

public interface IBoardGameRepository
{
    Task<BoardGame> GetBoardGameBySlugAsync(string slug);

    Task<IEnumerable<BoardGame>> GetAllBoardGamesAsync();
}