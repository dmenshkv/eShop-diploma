namespace Marketplace.UI.Core.Services;

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

        _baseApiPath = string.Format(ApiRouteTemplates.ApiFormat, _appSettings.Value.CatalogUrl, ApiEndpoints.BoardGame);
    }

    public async Task<BoardGameViewModel> CreateAsync(CreateBoardGameRequest request)
    {
        return await AddAsync(_baseApiPath, request);
    }

    public async Task<BoardGameViewModel> GetBySlugAsync(string slug)
    {
        return await _httpClientService.GetAsync<BoardGameViewModel>($"{_baseApiPath}/{slug}");
    }

    public async Task<GetAllBoardGamesResponse> GetAllAsync(ODataQueryParameters? queryParameters = null)
    {
        var baseODataUri = $"{_baseApiPath}/edm";
        var uri = queryParameters != null
            ? _urlBuilderService.BuildGetBoardGamesUri(baseODataUri, queryParameters)
            : _urlBuilderService.AddDefaultBoardGamesQueryParameters(baseODataUri);

        return await _httpClientService.GetAsync<GetAllBoardGamesResponse>(uri);
    }

    public async Task<BoardGameViewModel> UpdateAsync(Guid id, UpdateBoardGameRequest request)
    {
        return await UpdateAsync($"{_baseApiPath}/{id}", request);
    }

    public async Task DeleteAsync(Guid id)
    {
        await RemoveAsync($"{_baseApiPath}/{id}");
    }
}