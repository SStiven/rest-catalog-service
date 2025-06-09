using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;

public static class CategorySeeder
{
    public static void SeedDefaultCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasData(
                new { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Category 1" },
                new { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Name = "Category 2" },
                new { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Name = "Category 3" }
            );
    }
}
