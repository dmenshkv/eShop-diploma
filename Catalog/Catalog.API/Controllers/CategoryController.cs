namespace Catalog.API.Controllers;

[ApiController]
[Route(RouteConstants.Category)]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="request">The details of the category to create.</param>
    /// <returns>An HTTP response with a status of 201 Created if the category is successfully created.</returns>
    /// <response code="201">Returns the created category with a location header pointing to the newly created resource.</response>
    /// <response code="400">Returns Bad Request if the input data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateCategoryRequest request)
    {
        var response = await _categoryService.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>An HTTP response with a status of 200 OK if the category is found.</returns>
    /// <response code="200">Returns the category details.</response>
    /// <response code="404">Returns Not Found if no category is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _categoryService.GetByIdAsync(id);

        return Ok(response);
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>An HTTP response with a status of 200 OK and a list of all categories.</returns>
    /// <response code="200">Returns a list of all categories.</response>
    [HttpGet]
    [ProducesResponseType(typeof(GetItemsResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _categoryService.GetAllAsync();

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The unique identifier of the category to update.</param>
    /// <param name="category">The updated details of the category.</param>
    /// <returns>An HTTP response with a status of 200 OK if the category is successfully updated.</returns>
    /// <response code="200">Returns the updated category details.</response>
    /// <response code="400">Returns Bad Request if the provided ID does not match the ID in the request body.</response>
    /// <response code="404">Returns Not Found if no category is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, CategoryDto category)
    {
        if (id != category.Id)
        {
            return BadRequest(ErrorMessages.RouteAndBodyIdMismatchError);
        }

        var response = await _categoryService.UpdateAsync(id, category);

        return Ok(response);
    }

    /// <summary>
    /// Deletes a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to delete.</param>
    /// <returns>An HTTP response with a status of 204 No Content if the category is successfully deleted.</returns>
    /// <response code="204">Indicates that the category was successfully deleted.</response>
    /// <response code="404">Returns Not Found if no category is found with the provided ID.</response>
    /// <response code="500">Returns an Internal Server Error for unexpected issues.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _categoryService.DeleteAsync(id);

        return NoContent();
    }
}