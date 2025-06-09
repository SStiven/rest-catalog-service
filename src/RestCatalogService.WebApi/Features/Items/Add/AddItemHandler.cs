using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Items.Add;

public class AddItemHandler
{
    private readonly IItemRepository _repo;
    public AddItemHandler(IItemRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(AddItemCommand command)
    {
        var item = new Item(command.Name, command.CategoriesIds);
        await _repo.AddAsync(item);
        return item.Id;
    }
}