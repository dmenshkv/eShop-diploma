using Marketplace.Models;
using Marketplace.Models.Configurations;
using Marketplace.Models.Requests;
using Marketplace.Models.Responses;
using Marketplace.Models.ViewModels;
using Marketplace.UI.Core.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Core.Services
{
    public class BoardGameService : BaseService<BoardGameViewModel>, IBoardGameService
    {
        private readonly string _baseApiPath;

        private readonly IOptions<AppSettings> _appSettings;
        private readonly IUriBuilderService _urlBuilderService;

        public BoardGameService(
            IOptions<AppSettings> appSettings,
            IHttpClientService httpClientService,
            IUriBuilderService uriBuilderService)
            : base(httpClientService)
        {
            _appSettings = appSettings;
            _urlBuilderService = uriBuilderService;

            _baseApiPath = $"{_appSettings.Value.CatalogUrl}/board-games";
        }

        public async Task<AddItemResponse> AddBoardGameAsync(AddItemRequest<BoardGameViewModel> addItemRequest)
        {
            return await AddAsync(_baseApiPath, addItemRequest);
        }

        public async Task<GetAllBoardGamesResponse> GetAllBoardGamesAsync(ODataQueryParameters? queryParameters = null)
        {
            var baseODataUri = $"{_baseApiPath}/edm";
            var uri = queryParameters != null
                ? _urlBuilderService.BuildGetBoardGamesUri(baseODataUri, queryParameters)
                : _urlBuilderService.AddDefaultBoardGamesQueryParameters(baseODataUri);

            var result = await _httpClientService.GetAsync<GetAllBoardGamesResponse>(uri);

            return result;
        }

        public async Task<GetBoardGameBySlugResponse> GetBoardGameBySlugAsync(string slug)
        {
            var result = await _httpClientService.GetAsync<GetBoardGameBySlugResponse>($"{_baseApiPath}/{slug}");

            return result;
        }

        public async Task<RemoveItemResponse> RemoveBoardGameAsync(Guid id)
        {
            return await RemoveAsync($"{_baseApiPath}/{id}");
        }

        public async Task<UpdateItemResponse> UpdateBoardGameAsync(Guid id, UpdateItemRequest<BoardGameViewModel> updateItemRequest)
        {
            return await UpdateAsync($"{_baseApiPath}/{id}", updateItemRequest);
        }
    }
}