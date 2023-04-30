using AutoMapper;
using Catalog.Core.Services.Interfaces;
using Catalog.DataAccess.Repositories.Interfaces;
using Catalog.Entites.Common;
using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;

namespace Catalog.Core.Services
{
    public class BrandService : BaseService<Brand, BrandDto>, IBrandService
    {
        public BrandService(IMapper mapper, IBaseRepository<Brand> baseRepository)
            : base(mapper, baseRepository)
        {
        }

        public async Task<AddItemResponse> AddBrandAsync(AddItemRequest<BrandDto> addItemRequest)
        {
            return await AddAsync(addItemRequest);
        }

        public async Task<GetAllItemsResponse<BrandDto>> GetAllBrandsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<RemoveItemResponse> RemoveBrandAsync(Guid id)
        {
            return await RemoveAsync(id);
        }

        public async Task<UpdateItemResponse> UpdateBrandAsync(Guid id, UpdateItemRequest<BrandDto> updateItemRequest)
        {
            return await UpdateAsync(id, updateItemRequest);
        }
    }
}