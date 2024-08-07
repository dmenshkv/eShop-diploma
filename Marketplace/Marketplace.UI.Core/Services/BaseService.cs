namespace Marketplace.UI.Core.Services;

public class BaseService<TModel>
    where TModel : class
{
    protected readonly IHttpClientService _httpClientService;

    public BaseService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<AddItemResponse> AddAsync(string uri, AddItemRequest<TModel> addItemRequest)
    {
        return await _httpClientService.PostAsync<AddItemResponse, AddItemRequest<TModel>>(uri, addItemRequest);
    }

    public async Task<GetAllItemsResponse<TModel>> GetAllAsync(string uri)
    {
        return await _httpClientService.GetAsync<GetAllItemsResponse<TModel>>(uri);
    }

    public async Task<RemoveItemResponse> RemoveAsync(string uri)
    {
        return await _httpClientService.DeleteAsync<RemoveItemResponse>(uri);
    }

    public async Task<UpdateItemResponse> UpdateAsync(string uri, UpdateItemRequest<TModel> updateItemRequest)
    {
        return await _httpClientService.PutAsync<UpdateItemResponse, UpdateItemRequest<TModel>>(uri, updateItemRequest);
    }
}