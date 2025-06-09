namespace RestCatalogService.WebApi.Features.Items.Add;

public record AddItemRequest(string Name, IList<Guid> CategoryIds);