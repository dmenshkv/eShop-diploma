using Catalog.Core.Models.DTOs;
using Catalog.Core.Models.Requests;
using Catalog.Core.Models.Responses;

namespace Catalog.API.Controllers;

[ApiController]
[Route(RouteConstants.Brand)]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    /// <summary>
    /// Creates a new brand.
    /// </summary>
    /// <param name="request">The details of the brand to create.</param>
    /// <returns>An HTTP response with a status of 201 Created if the brand is successfully created.</returns>
    /// <response code="201">Returns the created brand with a location header pointing to the newly created resource.</response>
    /// <response code="400">Returns Bad Request if the input data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateBrandRequest request)
    {
        var response = await _brandService.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    /// <summary>
    /// Retrieves a brand by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the brand.</param>
    /// <returns>An HTTP response with a status of 200 OK if the brand is found.</returns>
    /// <response code="200">Returns the brand details.</response>
    /// <response code="404">Returns Not Found if no brand is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _brandService.GetByIdAsync(id);

        return Ok(response);
    }

    /// <summary>
    /// Retrieves all brands.
    /// </summary>
    /// <returns>An HTTP response with a status of 200 OK and a list of all brands.</returns>
    /// <response code="200">Returns a list of all brands.</response>
    [HttpGet]
    [ProducesResponseType(typeof(GetItemsResponse<BrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _brandService.GetAllAsync();

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing brand.
    /// </summary>
    /// <param name="id">The unique identifier of the brand to update.</param>
    /// <param name="brand">The updated details of the brand.</param>
    /// <returns>An HTTP response with a status of 200 OK if the brand is successfully updated.</returns>
    /// <response code="200">Returns the updated brand details.</response>
    /// <response code="400">Returns Bad Request if the provided ID does not match the ID in the request body.</response>
    /// <response code="404">Returns Not Found if no brand is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, BrandDto brand)
    {
        if (id != brand.Id)
        {
            return BadRequest(ErrorMessages.RouteAndBodyIdMismatchError);
        }

        var response = await _brandService.UpdateAsync(id, brand);

        return Ok(response);
    }

    /// <summary>
    /// Deletes a brand by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the brand to delete.</param>
    /// <returns>An HTTP response with a status of 204 No Content if the brand is successfully deleted.</returns>
    /// <response code="204">Indicates that the brand was successfully deleted.</response>
    /// <response code="404">Returns Not Found if no brand is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _brandService.DeleteAsync(id);

        return NoContent();
    }
}