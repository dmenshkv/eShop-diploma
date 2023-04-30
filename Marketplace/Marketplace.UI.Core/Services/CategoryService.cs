using Marketplace.Models.Configurations;
using Marketplace.Models.Requests;
using Marketplace.Models.Responses;
using Marketplace.Models.ViewModels;
using Marketplace.UI.Core.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Core.Services
{
    public class CategoryService : BaseService<CategoryViewModel>, ICategoryService
    {
        private readonly string _baseApiPath;

        private readonly IOptions<AppSettings> _appSettings;

        public CategoryService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
            : base(httpClientService)
        {
            _appSettings = appSettings;

            _baseApiPath = $"{_appSettings.Value.CatalogUrl}/categories";
        }

        public async Task<AddItemResponse> AddCategoryAsync(AddItemRequest<CategoryViewModel> addItemRequest)
        {
            return await AddAsync(_baseApiPath, addItemRequest);
        }

        public async Task<GetAllItemsResponse<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await GetAllAsync(_baseApiPath);
        }

        public async Task<RemoveItemResponse> RemoveCategoryAsync(Guid id)
        {
            return await RemoveAsync($"{_baseApiPath}/{id}");
        }

        public async Task<UpdateItemResponse> UpdateCategoryAsync(Guid id, UpdateItemRequest<CategoryViewModel> updateItemRequest)
        {
            return await UpdateAsync($"{_baseApiPath}/{id}", updateItemRequest);
        }
    }
}
