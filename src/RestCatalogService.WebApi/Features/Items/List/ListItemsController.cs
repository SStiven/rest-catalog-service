using Microsoft.AspNetCore.Mvc;

namespace RestCatalogService.WebApi.Features.Items.List;

[ApiController]
[Route("api/items")]
public class ListItemsController : ControllerBase
{
    private readonly ListItemsHandler _handler;

    public ListItemsController(ListItemsHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> ListItems()
    {
        var items = await _handler.Handle();
        return Ok(items.Select(c => c.ToResponse()).ToList());
    }
}
