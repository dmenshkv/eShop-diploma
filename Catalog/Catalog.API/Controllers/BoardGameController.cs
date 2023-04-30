using System.Net;
using Catalog.Core.Services.Interfaces;
using Catalog.Models.DTOs;
using Catalog.Models.Requests;
using Catalog.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("board-games")]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameService _boardGameService;

        public BoardGameController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] AddItemRequest<BoardGameDto> addItemRequest)
        {
            var response = await _boardGameService.AddBoardGameAsync(addItemRequest);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateItemRequest<BoardGameDto> updateItemRequest)
        {
            if (id != updateItemRequest.Item.Id)
            {
                return BadRequest("Id in the route must match the id in the request body.");
            }

            var response = await _boardGameService.UpdateBoardGameAsync(id, updateItemRequest);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RemoveItemResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var response = await _boardGameService.RemoveBoardGameAsync(id);

            return Ok(response);
        }

        [HttpGet("edm")]
        [EnableQuery]
        [ODataAttributeRouting]
        [ProducesResponseType(typeof(IEnumerable<BoardGameDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _boardGameService.GetAllBoardGamesAsync();

            return Ok(response);
        }

        [HttpGet("{slug}")]
        [ProducesResponseType(typeof(GetBoardGameBySlugResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySlugAsync(string slug)
        {
            var response = await _boardGameService.GetBoardGameBySlugAsync(slug);

            return Ok(response);
        }
    }
}