namespace RestCatalogService.WebApi.Features.Items.Update;

public record UpdateItemCommand(Guid Id, string Name, IList<Guid> CategoriesIds);