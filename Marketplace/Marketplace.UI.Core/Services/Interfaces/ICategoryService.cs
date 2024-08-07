﻿namespace Marketplace.UI.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<AddItemResponse> AddCategoryAsync(AddItemRequest<CategoryViewModel> addItemRequest);

    Task<UpdateItemResponse> UpdateCategoryAsync(Guid id, UpdateItemRequest<CategoryViewModel> updateItemRequest);

    Task<RemoveItemResponse> RemoveCategoryAsync(Guid id);

    Task<GetAllItemsResponse<CategoryViewModel>> GetAllCategoriesAsync();
}