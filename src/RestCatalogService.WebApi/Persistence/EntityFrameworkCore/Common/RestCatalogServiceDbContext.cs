using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.ItemCategories;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Items;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;

public class RestCatalogServiceDbContext(DbContextOptions<RestCatalogServiceDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new ItemCategoryConfiguration());

        modelBuilder.SeedDefaultCategories();
    }
}
