namespace RestCatalogService.WebApi.Domain.Interfaces;

public interface IItemRepository
{
    Task AddAsync(Item item);
}
