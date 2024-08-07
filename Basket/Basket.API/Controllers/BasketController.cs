using Basket.Core.Services.Interfaces;
using Basket.Models.DTOs;
using Basket.Models.Requests;
using Basket.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers;

[ApiController]
[Route("basket")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService; 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerBasketDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _basketService.GetBasketAsync(id);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync([FromBody] AddItemRequest addItemRequest)
    {
        var result = await _basketService.AddToBasketAsync(addItemRequest);

        return Ok(result);
    }

    [HttpDelete("{id}/{itemId}")]
    [ProducesResponseType(typeof(RemoveItemResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveItemAsync(Guid id, Guid itemId)
    {
        var result = await _basketService.RemoveFromBasketAsync(id, itemId);

        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateQuantityResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateQuantity(Guid id, [FromBody] UpdateQuantityRequest updateQuantityRequest)
    {
        if (id != updateQuantityRequest.Id)
        {
            return BadRequest("Id in the route must match the id in the request body.");
        }

        var result = await _basketService.UpdateQuantityAsync(updateQuantityRequest);

        return Ok(result);
    }
}