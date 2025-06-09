using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain;

namespace RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;

public static class CategorySeeder
{
    public static void SeedDefaultCategories(this ModelBuilder modelBuilder)
    {
        var category1 = new Category(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Category 1");
        var category2 = new Category(Guid.Parse("11111111-1111-1111-1111-111111111112"), "Category 2");
        var category3 = new Category(Guid.Parse("11111111-1111-1111-1111-111111111113"), "Category 3");

        modelBuilder.Entity<Category>()
            .HasData(
                category1,
                category2,
                category3
            );
    }
}
