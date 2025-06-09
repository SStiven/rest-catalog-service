using Microsoft.AspNetCore.Mvc;

namespace RestCatalogService.WebApi.Features.Categories.Add;

[ApiController]
[Route("api/categories")]
public class AddCategoryController : ControllerBase
{
    private readonly AddCategoryHandler _handler;
    public AddCategoryController(AddCategoryHandler handler)
        => _handler = handler;

    [HttpPost]
    public async Task<IActionResult> Post(AddCategoryRequest request)
    {
        var command = new AddCategoryCommand(request.Name);
        var id = await _handler.Handle(command);
        return CreatedAtAction(null, new { id }, null);
    }
}
