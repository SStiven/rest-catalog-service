using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Features.Categories.List;

namespace RestCatalogService.WebApi.Features.Items.List;

public static class ItemMapper
{
    public static ItemResponse ToResponse(this Item item)
    {
        var categories = item.ItemCategories.Select(ic => new CategoryResponse(ic.CategoryId, ic.Category.Name));

        return new ItemResponse(
            item.Id,
            item.Name,
            categories
        );
    }
}
