using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Items;

public class SqlServerItemRepository : IItemRepository
{
    private readonly RestCatalogServiceDbContext _context;

    public SqlServerItemRepository(RestCatalogServiceDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Item>> ListAsync()
    {
        var items = await _context
            .Items
            .Include(i => i.ItemCategories)
            .ThenInclude(ic => ic.Category)
            .AsNoTracking()
            .ToListAsync();

        return items;
    }
}
