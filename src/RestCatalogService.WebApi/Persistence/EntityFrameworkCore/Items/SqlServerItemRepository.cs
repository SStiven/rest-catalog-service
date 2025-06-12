using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;
using RestCatalogService.WebApi.Features.Items.List;
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

    public async Task DeleteAsync(Item item)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Item?> FindByIdAsync(Guid id)
    {
        return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Item>> ListAsync(ISpecification<Item> specification, int page, int size)
    {
        var items = await _context
            .Items
            .Include(i => i.ItemCategories)
            .ThenInclude(ic => ic.Category)
            .Where(specification.Criteria)
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();

        return items;
    }
}
