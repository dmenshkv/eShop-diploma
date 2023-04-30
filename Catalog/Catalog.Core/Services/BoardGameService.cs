using AutoMapper;
using Catalog.Core.Services.Interfaces;
using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.Entites.Common;
using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;

namespace Catalog.Core.Services
{
    public class BoardGameService : BaseService<BoardGame, BoardGameDto>, IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;

        public BoardGameService(
            IMapper mapper,
            IBaseRepository<BoardGame> baseRepository,
            IBoardGameRepository boardGameRepository)
            : base(mapper, baseRepository)
        {
            _boardGameRepository = boardGameRepository;
        }

        public async Task<AddItemResponse> AddBoardGameAsync(AddItemRequest<BoardGameDto> addItemRequest)
        {
            return await AddAsync(addItemRequest);
        }

        public async Task<IEnumerable<BoardGameDto>> GetAllBoardGamesAsync()
        {
            var boardGames = await _boardGameRepository.GetAllBoardGamesAsync();

            return _mapper.Map<IEnumerable<BoardGameDto>>(boardGames);
        }

        public async Task<GetBoardGameBySlugResponse> GetBoardGameBySlugAsync(string slug)
        {
            var boardGame = await _boardGameRepository.GetBoardGameBySlugAsync(slug);

            return new GetBoardGameBySlugResponse()
            {
                BoardGame = _mapper.Map<BoardGameDto>(boardGame)
            };
        }

        public async Task<RemoveItemResponse> RemoveBoardGameAsync(Guid id)
        {
            return await RemoveAsync(id);
        }

        public async Task<UpdateItemResponse> UpdateBoardGameAsync(Guid id, UpdateItemRequest<BoardGameDto> updateItemRequest)
        {
            return await UpdateAsync(id, updateItemRequest);
        }
    }
}