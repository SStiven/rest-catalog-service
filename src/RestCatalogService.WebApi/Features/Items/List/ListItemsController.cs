using Microsoft.AspNetCore.Mvc;
using RestCatalogService.WebApi.Features.Common;

namespace RestCatalogService.WebApi.Features.Items.List;

[ApiController]
[Route("api/items")]
public class ListItemsController : ControllerErrorOr
{
    private readonly ListItemsHandler _handler;

    public ListItemsController(ListItemsHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> ListItems(
        [FromQuery] Guid? categoryId = null,
        [FromQuery] int page = 1,
        [FromQuery] int size = 2)
    {
        var result = await _handler.Handle(categoryId, page, size);

        return result.Match(
            items => Ok(items.Select(c => c.ToResponse()).ToList()),
            Problem
            );
    }
}
