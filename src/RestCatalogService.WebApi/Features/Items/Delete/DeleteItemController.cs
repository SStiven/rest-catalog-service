using Microsoft.AspNetCore.Mvc;
using RestCatalogService.WebApi.Features.Common;

namespace RestCatalogService.WebApi.Features.Items.Delete;

[ApiController]
[Route("api/items")]
public class DeleteItemController : ControllerErrorOr
{
    private readonly DeleteItemHandler _handler;

    public DeleteItemController(DeleteItemHandler handler)
    {
        _handler = handler;
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Post([FromRoute] Guid id)
    {
        var command = new DeleteItemCommand(id);
        var result = await _handler.Handle(command);
        return result.Match(
            _ => NoContent(),
            Problem
            );
    }
}
