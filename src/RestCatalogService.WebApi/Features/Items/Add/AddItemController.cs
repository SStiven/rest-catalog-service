using Microsoft.AspNetCore.Mvc;

namespace RestCatalogService.WebApi.Features.Items.Add;

[ApiController]
[Route("api/items")]
public class AddItemController : ControllerBase
{
    private readonly AddItemHandler _handler;

    public AddItemController(AddItemHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddItemRequest request)
    {
        var command = new AddItemCommand(request.Name, request.CategoryIds);
        var id = await _handler.Handle(command);
        return CreatedAtAction(null, new { id }, null);
    }
}
