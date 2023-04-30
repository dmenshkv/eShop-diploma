using Marketplace.Models.Configurations;
using Marketplace.Models.Requests;
using Marketplace.Models.Responses;
using Marketplace.Models.ViewModels;
using Marketplace.UI.Core.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Core.Services
{
    public class MechanicService : BaseService<MechanicViewModel>, IMechanicService
    {
        private readonly string _baseApiPath;

        private readonly IOptions<AppSettings> _appSettings;

        public MechanicService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
            : base(httpClientService)
        {
            _appSettings = appSettings;

            _baseApiPath = $"{_appSettings.Value.CatalogUrl}/mechanics";
        }

        public async Task<AddItemResponse> AddMechanicAsync(AddItemRequest<MechanicViewModel> addItemRequest)
        {
            return await AddAsync(_baseApiPath, addItemRequest);
        }

        public async Task<GetAllItemsResponse<MechanicViewModel>> GetAllMechanicsAsync()
        {
            return await GetAllAsync(_baseApiPath);
        }

        public async Task<RemoveItemResponse> RemoveMechanicAsync(Guid id)
        {
            return await RemoveAsync($"{_baseApiPath}/{id}");
        }

        public async Task<UpdateItemResponse> UpdateMechanicAsync(Guid id, UpdateItemRequest<MechanicViewModel> updateItemRequest)
        {
            return await UpdateAsync($"{_baseApiPath}/{id}", updateItemRequest);
        }
    }
}