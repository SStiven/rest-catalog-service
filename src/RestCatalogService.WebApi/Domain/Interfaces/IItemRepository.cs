using RestCatalogService.WebApi.Features.Items.List;

namespace RestCatalogService.WebApi.Domain.Interfaces;

public interface IItemRepository
{
    Task AddAsync(Item item);

    Task<List<Item>> ListAsync(ISpecification<Item> specification, int page, int size);

    Task<Item?> FindByIdAsync(Guid id);

    Task DeleteAsync(Item item);

    Task UpdateAsync(Item item);
}
