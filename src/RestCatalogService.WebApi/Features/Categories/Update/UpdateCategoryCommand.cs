namespace RestCatalogService.WebApi.Features.Categories.Update;

public record UpdateCategoryCommand(Guid Id, string Name);