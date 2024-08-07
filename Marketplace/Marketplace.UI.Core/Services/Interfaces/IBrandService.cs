﻿namespace Marketplace.UI.Core.Services.Interfaces;

public interface IBrandService
{
    Task<AddItemResponse> AddBrandAsync(AddItemRequest<BrandViewModel> addItemRequest);

    Task<UpdateItemResponse> UpdateBrandAsync(Guid id, UpdateItemRequest<BrandViewModel> updateItemRequest);

    Task<RemoveItemResponse> RemoveBrandAsync(Guid id);

    Task<GetAllItemsResponse<BrandViewModel>> GetAllBrandsAsync();
}