using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Items.List;

public class ListItemsHandler
{
    private readonly IItemRepository _repo;

    public ListItemsHandler(IItemRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Item>> Handle()
    {
        return await _repo.ListAsync();
    }
}