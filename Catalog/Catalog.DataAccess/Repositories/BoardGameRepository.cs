using Catalog.DataAccess.Exceptions;
using Catalog.DataAccess.Repositories.Interfaces;

namespace Catalog.DataAccess.Repositories;

public class BoardGameRepository : BaseRepository<BoardGame>, IBoardGameRepository
{
    public BoardGameRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    {
    }

    public async Task<IEnumerable<BoardGame>> GetAllBoardGamesAsync()
    {
        var boardGames = await _applicationDbContext.BoardGames
            .Include(i => i.Brand)
            .Include(i => i.Categories)
            .Include(i => i.Mechanics)
            .ToListAsync();

        return boardGames;
    }

    public async Task<BoardGame> GetBoardGameBySlugAsync(string slug)
    {
        var boardGame = await _applicationDbContext.BoardGames
            .Where(w => w.Slug == slug)
            .Include(i => i.Brand)
            .Include(i => i.Categories)
            .Include(i => i.Mechanics)
            .FirstOrDefaultAsync();

        if (boardGame == null)
        {
            throw new EntityNotFoundException($"Board game with the slug {slug} was not found");
        }

        return boardGame;
    }
}