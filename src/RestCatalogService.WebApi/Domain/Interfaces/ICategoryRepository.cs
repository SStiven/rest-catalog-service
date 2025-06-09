namespace RestCatalogService.WebApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
}
