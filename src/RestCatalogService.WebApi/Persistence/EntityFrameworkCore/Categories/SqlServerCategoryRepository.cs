using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;

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
}
