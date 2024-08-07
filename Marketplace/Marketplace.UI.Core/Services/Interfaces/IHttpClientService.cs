namespace Marketplace.UI.Core.Services.Interfaces;

public interface IHttpClientService
{
    Task<TResponse> PostAsync<TResponse, TRequest>(string uri, TRequest body);

    Task<TResponse> PutAsync<TResponse, TRequest>(string uri, TRequest body);

    Task<TResponse> DeleteAsync<TResponse>(string uri);

    Task<TResponse> GetAsync<TResponse>(string uri);
}