using Microsoft.AspNetCore.Mvc;
using RestCatalogService.WebApi.Features.Common;

namespace RestCatalogService.WebApi.Features.Items.Update;

[ApiController]
[Route("api/items")]
public class UpdateItemController : ControllerErrorOr
{
    private readonly UpdateItemHandler _handler;

    public UpdateItemController(UpdateItemHandler handler)
    {
        _handler = handler;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateItemRequest request)
    {
        var command = new UpdateItemCommand(id, request.Name, request.CategoryIds);
        var result = await _handler.Handle(command);

        return result.Match(
            _ => Ok(),
            Problem);
    }
}
