namespace Catalog.API.Controllers;

[ApiController]
[Route("mechanics")]
public class MechanicController : Controller
{
    private readonly IMechanicService _mechanicService;

    public MechanicController(IMechanicService mechanicService)
    {
        _mechanicService = mechanicService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromBody] AddItemRequest<MechanicDto> addItemRequest)
    {
        var response = await _mechanicService.AddMechanicAsync(addItemRequest);

        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateItemResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateItemRequest<MechanicDto> updateItemRequest)
    {
        if (id != updateItemRequest.Item.Id)
        {
            return BadRequest("Id in the route must match the id in the request body.");
        }

        var response = await _mechanicService.UpdateMechanicAsync(id, updateItemRequest);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(RemoveItemResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        var response = await _mechanicService.RemoveMechanicAsync(id);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllItemsResponse<MechanicDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mechanicService.GetAllMechanicsAsync();

        return Ok(response);
    }
}