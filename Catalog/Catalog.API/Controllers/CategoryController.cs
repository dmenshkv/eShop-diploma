using System.Net;
using Catalog.Core.Services.Interfaces;
using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] AddItemRequest<CategoryDto> addItemRequest)
        {
            var response = await _categoryService.AddCategoryAsync(addItemRequest);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateItemRequest<CategoryDto> updateItemRequest)
        {
            if (id != updateItemRequest.Item.Id)
            {
                return BadRequest("Id in the route must match the id in the request body.");
            }

            var response = await _categoryService.UpdateCategoryAsync(id, updateItemRequest);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RemoveItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var response = await _categoryService.RemoveCategoryAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllItemsResponse<CategoryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _categoryService.GetAllCategoriesAsync();

            return Ok(response);
        }
    }
}
