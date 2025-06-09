using Microsoft.AspNetCore.Mvc;

namespace RestCatalogService.WebApi.Features.Categories.List;

[ApiController]
[Route("api/categories")]
public class ListCategoriesController : ControllerBase
{
    private readonly ListCategoriesHandler _handler;

    public ListCategoriesController(ListCategoriesHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    public async Task<IActionResult> ListAllCategories()
    {
        var categories = await _handler.Handle();
        return Ok(categories.Select(c => c.ToResponse()).ToList());
    }
}
