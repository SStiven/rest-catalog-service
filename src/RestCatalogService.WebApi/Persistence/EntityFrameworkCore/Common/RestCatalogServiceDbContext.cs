using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;

public class RestCatalogServiceDbContext(DbContextOptions<RestCatalogServiceDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        modelBuilder.SeedDefaultCategories();
    }
}
