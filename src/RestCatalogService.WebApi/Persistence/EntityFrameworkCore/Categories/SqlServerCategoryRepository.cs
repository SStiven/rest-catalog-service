using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;
using System.Threading.Tasks;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;

public class SqlServerCategoryRepository : ICategoryRepository
{
    private readonly RestCatalogServiceDbContext _context;

    public SqlServerCategoryRepository(RestCatalogServiceDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Category>> ListAsync()
    {
        var categories = await _context
            .Categories
            .AsNoTracking()
            .ToListAsync();
        return categories;
    }

    public async Task<Category?> FindByIdAsync(Guid id)
    {
        var maybeCategory = await _context
            .Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        return maybeCategory;
    }

    public Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        return Task.CompletedTask;
    }

    public async Task<bool> AreAllPresentAsync(IList<Guid> categoriesIds)
    {
        var categoriesCount = await _context
            .Categories
            .AsNoTracking()
            .Where(c => categoriesIds.Contains(c.Id))
            .CountAsync();

        return categoriesIds.Count == categoriesCount;
    }
}
