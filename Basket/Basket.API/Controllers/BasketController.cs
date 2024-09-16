using System.Net;
using Basket.API.Constants;
using Basket.Core.Models.DTOs;
using Basket.Core.Models.Requests;
using Basket.Core.Models.Responses;
using Basket.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route(RouteConstants.Basket)]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService; 
    }

    /// <summary>
    /// Adds an item to the basket.
    /// </summary>
    /// <param name="request">The request containing the item details to be added to the basket.</param>
    /// <returns>An <see cref="IActionResult"/> containing the result of the operation.</returns>
    /// <response code="200">Returns the added item details in <see cref="AddItemResponse"/>.</response>
    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddBasketItem(AddItemRequest request)
    {
        var result = await _basketService.AddBasketItemAsync(request);

        return Ok(result);
    }

    /// <summary>
    /// Retrieves the basket for a specified customer by their ID.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>An <see cref="IActionResult"/> containing the customer basket if found, otherwise a 404 Not Found response.</returns>
    /// <response code="200">Returns the customer basket for the given ID.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerBasketDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBasket(Guid id)
    {
        var result = await _basketService.GetBasketAsync(id);

        return Ok(result);
    }

    /// <summary>
    /// Updates the basket for a specified customer by their ID.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <param name="request">The request object containing the updated basket information.</param>
    /// <returns>An <see cref="IActionResult"/> containing the updated customer basket.</returns>
    /// <response code="200">Returns the updated customer basket.</response>
    /// <response code="400">Returns a Bad Request error if the ID in the request body does not match the route parameter.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(CustomerBasketDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBasket(Guid id, UpdateBasketRequest request)
    {
        if (id != request.CustomerId)
        {
            return BadRequest(ErrorMessages.RouteAndBodyIdMismatchError);
        }

        var result = await _basketService.UpdateBasketAsync(request);

        return Ok(result);
    }
}