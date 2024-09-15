using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;

namespace Catalog.API.Controllers;

[ApiController]
[Route(RouteConstants.BoardGame)]
public class BoardGameController : ControllerBase
{
    private readonly IBoardGameService _boardGameService;

    public BoardGameController(IBoardGameService boardGameService)
    {
        _boardGameService = boardGameService;
    }

    /// <summary>
    /// Creates a new board game.
    /// </summary>
    /// <param name="request">The details of the board game to create.</param>
    /// <returns>An HTTP response with a status of 201 Created if the board game is successfully created.</returns>
    /// <response code="201">Returns the created board game with a location header pointing to the newly created resource.</response>
    /// <response code="400">Returns a Bad Request if the input data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(BoardGameDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateBoardGameRequest request)
    {
        var response = await _boardGameService.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new { slug = response.Slug }, response);
    }

    /// <summary>
    /// Retrieves a board game by its unique slug.
    /// </summary>
    /// <param name="slug">The unique slug of the board game.</param>
    /// <returns>An HTTP response with a status of 200 OK if the board game is found.</returns>
    /// <response code="200">Returns the board game details.</response>
    /// <response code="404">Returns Not Found if no board game is found with the provided slug.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpGet("{slug}")]
    [ProducesResponseType(typeof(BoardGameDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(string slug)
    {
        var response = await _boardGameService.GetBySlugAsync(slug);

        return Ok(response);
    }

    /// <summary>
    /// Retrieves all board games.
    /// </summary>
    /// <returns>An HTTP response with a status of 200 OK and a list of all board games.</returns>
    /// <response code="200">Returns a list of all board games.</response>
    [HttpGet("edm")]
    [EnableQuery]
    [ODataAttributeRouting]
    [ProducesResponseType(typeof(IEnumerable<BoardGameDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _boardGameService.GetAllAsync();

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing board game.
    /// </summary>
    /// <param name="id">The unique identifier of the board game to update.</param>
    /// <param name="request">The updated details of the board game.</param>
    /// <returns>An HTTP response with a status of 200 OK if the board game is successfully updated.</returns>
    /// <response code="200">Returns the updated board game details.</response>
    /// <response code="400">Returns Bad Request if the provided ID does not match the ID in the request body.</response>
    /// <response code="404">Returns Not Found if no board game is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(BoardGameDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, UpdateBoardGameRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest(ErrorMessages.RouteAndBodyIdMismatchError);
        }

        var response = await _boardGameService.UpdateAsync(id, request);

        return Ok(response);
    }

    /// <summary>
    /// Deletes a board game by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the board game to delete.</param>
    /// <returns>An HTTP response with a status of 204 No Content if the board game is successfully deleted.</returns>
    /// <response code="204">Indicates that the board game was successfully deleted.</response>
    /// <response code="404">Returns Not Found if no board game is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _boardGameService.DeleteAsync(id);

        return NoContent();
    }
}