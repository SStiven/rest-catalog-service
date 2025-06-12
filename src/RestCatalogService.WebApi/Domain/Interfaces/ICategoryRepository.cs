namespace RestCatalogService.WebApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<IReadOnlyList<Category>> ListAsync();
    Task<Category?> FindByIdAsync(Guid id);
    Task UpdateAsync(Category category);
    Task<bool> AreAllPresentAsync(IList<Guid> categoriesIds);
}
