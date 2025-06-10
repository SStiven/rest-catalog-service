using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Features.Categories.List;

namespace RestCatalogService.WebApi.Features.Items.List;

public record ItemResponse(Guid Id, string Name, IEnumerable<CategoryResponse> Categories);