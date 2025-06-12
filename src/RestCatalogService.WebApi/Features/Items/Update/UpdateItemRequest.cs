namespace RestCatalogService.WebApi.Features.Items.Update;

public record UpdateItemRequest(string Name, IList<Guid> CategoryIds);