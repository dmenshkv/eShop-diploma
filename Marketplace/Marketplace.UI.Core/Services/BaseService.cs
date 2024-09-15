namespace Marketplace.UI.Core.Services;

public class BaseService<TResponse>
    where TResponse : class
{
    protected readonly IHttpClientService _httpClientService;

    public BaseService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<TResponse> AddAsync<TRequest>(string uri, TRequest request)
        where TRequest : class
    {
        return await _httpClientService.PostAsync<TResponse, TRequest>(uri, request);
    }

    public async Task<TResponse> GetAsync(string uri)
    {
        return await _httpClientService.GetAsync<TResponse>(uri);
    }

    public async Task<GetItemsResponse<TResponse>> GetAllAsync(string uri)
    {
        return await _httpClientService.GetAsync<GetItemsResponse<TResponse>>(uri);
    }

    public async Task<TResponse> UpdateAsync<TRequest>(string uri, TRequest request)
        where TRequest : class
    {
        return await _httpClientService.PutAsync<TResponse, TRequest>(uri, request);
    }

    public async Task RemoveAsync(string uri)
    {
        await _httpClientService.DeleteAsync(uri);
    }
}