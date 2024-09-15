namespace Catalog.Core.Services;

public class BoardGameService : BaseService<BoardGame, BoardGameDto>, IBoardGameService
{
    private readonly IBaseRepository<Mechanic> _mechanicRepository;
    private readonly IBaseRepository<Category> _categoryRepository;
    private readonly IBoardGameRepository _boardGameRepository;

    public BoardGameService(
        IMapper mapper,
        IBaseRepository<BoardGame> baseRepository,
        IBaseRepository<Mechanic> mechanicRepository,
        IBaseRepository<Category> categoryRepository,
        IBoardGameRepository boardGameRepository)
        : base(mapper, baseRepository)
    {
        _mechanicRepository = mechanicRepository;
        _categoryRepository = categoryRepository;
        _boardGameRepository = boardGameRepository;
    }

    public override async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }

    public async Task<BoardGameDto> CreateAsync(CreateBoardGameRequest request)
    {
        var mappedBoardGame = _mapper.Map<BoardGame>(request);

        var mechanics = await _mechanicRepository.FilterAsync(m => request.MechanicIds.Contains(m.Id), false);
        var categories = await _categoryRepository.FilterAsync(c => request.CategoryIds.Contains(c.Id), false);

        mappedBoardGame.Mechanics = mechanics.ToList();
        mappedBoardGame.Categories = categories.ToList();

        var boardGame = await _boardGameRepository.CreateAsync(mappedBoardGame);

        return _mapper.Map<BoardGameDto>(boardGame);
    }

    public async Task<BoardGameDto> GetBySlugAsync(string slug)
    {
        var boardGame = await _boardGameRepository.GetBySlugAsync(slug);

        return _mapper.Map<BoardGameDto>(boardGame);
    }

    public new async Task<IEnumerable<BoardGameDto>> GetAllAsync()
    {
        var boardGames = await _boardGameRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<BoardGameDto>>(boardGames);
    }

    public async Task<BoardGameDto> UpdateAsync(Guid id, UpdateBoardGameRequest request)
    {
        var mappedBoardGame = _mapper.Map<BoardGame>(request);

        var mechanics = await _mechanicRepository.FilterAsync(m => request.MechanicIds.Contains(m.Id), false);
        var categories = await _categoryRepository.FilterAsync(c => request.CategoryIds.Contains(c.Id), false);

        mappedBoardGame.Mechanics = mechanics.ToList();
        mappedBoardGame.Categories = categories.ToList();

        var boardGame = await _boardGameRepository.UpdateAsync(id, mappedBoardGame);

        return _mapper.Map<BoardGameDto>(boardGame);
    }
}