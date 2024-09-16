using Catalog.Core.Models.DTOs;
using Catalog.Core.Models.Requests;
using Catalog.Core.Models.Responses;

namespace Catalog.API.Controllers;

[ApiController]
[Route(RouteConstants.Mechanic)]
public class MechanicController : Controller
{
    private readonly IMechanicService _mechanicService;

    public MechanicController(IMechanicService mechanicService)
    {
        _mechanicService = mechanicService;
    }

    /// <summary>
    /// Creates a new mechanic.
    /// </summary>
    /// <param name="request">The details of the mechanic to create.</param>
    /// <returns>An HTTP response with a status of 201 Created if the mechanic is successfully created.</returns>
    /// <response code="201">Returns the created mechanic with a location header pointing to the newly created resource.</response>
    /// <response code="400">Returns Bad Request if the input data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(MechanicDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateMechanicRequest request)
    {
        var response = await _mechanicService.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    /// <summary>
    /// Retrieves a mechanic by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the mechanic.</param>
    /// <returns>An HTTP response with a status of 200 OK if the mechanic is found.</returns>
    /// <response code="200">Returns the mechanic details.</response>
    /// <response code="404">Returns Not Found if no mechanic is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MechanicDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _mechanicService.GetByIdAsync(id);

        return Ok(response);
    }

    /// <summary>
    /// Retrieves all mechanics.
    /// </summary>
    /// <returns>An HTTP response with a status of 200 OK and a list of all mechanics.</returns>
    /// <response code="200">Returns a list of all mechanics.</response>
    [HttpGet]
    [ProducesResponseType(typeof(GetItemsResponse<MechanicDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mechanicService.GetAllAsync();

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing mechanic.
    /// </summary>
    /// <param name="id">The unique identifier of the mechanic to update.</param>
    /// <param name="mechanic">The updated details of the mechanic.</param>
    /// <returns>An HTTP response with a status of 200 OK if the mechanic is successfully updated.</returns>
    /// <response code="200">Returns the updated mechanic details.</response>
    /// <response code="400">Returns Bad Request if the provided ID does not match the ID in the request body.</response>
    /// <response code="404">Returns Not Found if no mechanic is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(MechanicDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, MechanicDto mechanic)
    {
        if (id != mechanic.Id)
        {
            return BadRequest(ErrorMessages.RouteAndBodyIdMismatchError);
        }

        var response = await _mechanicService.UpdateAsync(id, mechanic);

        return Ok(response);
    }

    /// <summary>
    /// Deletes a mechanic by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the mechanic to delete.</param>
    /// <returns>An HTTP response with a status of 204 No Content if the mechanic is successfully deleted.</returns>
    /// <response code="204">Indicates that the mechanic was successfully deleted.</response>
    /// <response code="404">Returns Not Found if no mechanic is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mechanicService.DeleteAsync(id);

        return NoContent();
    }
}