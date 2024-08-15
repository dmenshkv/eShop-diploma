using Catalog.DataAccess.Exceptions;
using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.DataAccess.Resources;

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
            .AsNoTracking()
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
            .FirstOrDefaultAsync()
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.BoardGameNotFoundError, slug));

        return boardGame;
    }
}