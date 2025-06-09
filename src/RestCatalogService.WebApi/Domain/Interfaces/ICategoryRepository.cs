namespace RestCatalogService.WebApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<IReadOnlyList<Category>> ListAsync();
}
