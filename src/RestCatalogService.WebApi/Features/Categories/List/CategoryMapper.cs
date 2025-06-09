using RestCatalogService.WebApi.Domain;

namespace RestCatalogService.WebApi.Features.Categories.List;

public static class CategoryMapper
{
    public static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse(
            category.Id,
            category.Name
        );
    }
}
