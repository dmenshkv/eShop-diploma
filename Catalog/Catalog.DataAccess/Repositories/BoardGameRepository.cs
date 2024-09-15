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

    public override async Task<BoardGame> CreateAsync(BoardGame boardGame)
    {
        return await base.CreateAsync(boardGame);
    }

    public override async Task<BoardGame> UpdateAsync(Guid id, BoardGame boardGame)
    {
        if (boardGame == null)
        {
            throw new ArgumentNullException(nameof(boardGame), ErrorMessages.UpdateItemNullError);
        }

        var existingEntity = await _applicationDbContext.BoardGames
            .Include(bg => bg.Brand)
            .Include(bg => bg.Categories)
            .Include(bg => bg.Mechanics)
            .SingleOrDefaultAsync(e => e.Id == id)
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.ItemNotFoundError, id));

        _applicationDbContext.Entry(existingEntity).CurrentValues.SetValues(boardGame);

        if (boardGame.Categories != null)
        {
            _applicationDbContext.Entry(existingEntity).Collection(bg => bg.Categories!).CurrentValue = boardGame.Categories;
        }

        if (boardGame.Mechanics != null)
        {
            _applicationDbContext.Entry(existingEntity).Collection(bg => bg.Mechanics!).CurrentValue = boardGame.Mechanics;
        }

        await _applicationDbContext.SaveChangesAsync();

        return boardGame;
    }

    public override async Task<IReadOnlyList<BoardGame>> GetAllAsync()
    {
        return await _applicationDbContext.BoardGames
            .Include(bg => bg.Brand)
            .Include(bg => bg.Categories)
            .Include(bg => bg.Mechanics)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BoardGame> GetBySlugAsync(string slug)
    {
        var boardGame = await _applicationDbContext.BoardGames
            .Where(bg => bg.Slug == slug)
            .Include(bg => bg.Brand)
            .Include(bg => bg.Categories)
            .Include(bg => bg.Mechanics)
            .AsNoTracking()
            .SingleOrDefaultAsync()
            ?? throw new EntityNotFoundException(string.Format(ErrorMessages.BoardGameNotFoundError, slug));

        return boardGame;
    }
}