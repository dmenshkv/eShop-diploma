using System.Net;
using Catalog.Core.Services.Interfaces;
using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] AddItemRequest<BrandDto> addItemRequest)
        {
            var response = await _brandService.AddBrandAsync(addItemRequest);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateItemRequest<BrandDto> updateItemRequest)
        {
            if (id != updateItemRequest.Item.Id)
            {
                return BadRequest("Id in the route must match the id in the request body.");
            }

            var response = await _brandService.UpdateBrandAsync(id, updateItemRequest);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RemoveItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var response = await _brandService.RemoveBrandAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllItemsResponse<BrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _brandService.GetAllBrandsAsync();

            return Ok(response);
        }
    }
}
