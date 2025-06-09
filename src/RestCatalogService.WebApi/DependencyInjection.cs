using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain.Interfaces;
using RestCatalogService.WebApi.Features.Categories.Add;
using RestCatalogService.WebApi.Features.Categories.List;
using RestCatalogService.WebApi.Features.Categories.Update;
using RestCatalogService.WebApi.Features.Items.Add;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Items;

namespace RestCatalogService.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, SqlServerCategoryRepository>();
        services.AddScoped<IItemRepository, SqlServerItemRepository>();

        services.AddDbContext<RestCatalogServiceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RestCatalogServiceSqlServerConnection"));
        });

        //using (var serviceProvider = services.BuildServiceProvider())
        //{
        //    var dbContext = serviceProvider.GetRequiredService<RestCatalogServiceDbContext>();
        //    dbContext.Database.Migrate();
        //}

        services.AddTransient<AddCategoryHandler>();
        services.AddTransient<ListCategoriesHandler>();
        services.AddTransient<UpdateCategoryHandler>();

        services.AddTransient<AddItemHandler>();

        return services;
    }
}
