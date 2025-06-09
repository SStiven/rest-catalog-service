namespace RestCatalogService.WebApi.Features.Items.Add;

public record AddItemCommand(string Name, IList<Guid> CategoriesIds);