using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace RestCatalogService.WebApi.Features.Categories.Update;

[ApiController]
[Route("api/categories")]
public class UpdateCategoryController : ControllerBase
{
    private readonly UpdateCategoryHandler _handler;
    public UpdateCategoryController(UpdateCategoryHandler handler)
    {
        _handler = handler;
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request)
    {
        var command = new UpdateCategoryCommand(id, request.Name);
        var result = await _handler.Handle(command);
        if (result.FirstError.Type == ErrorType.NotFound)
        {
            return NotFound();
        }

        return NoContent();
    }
}
