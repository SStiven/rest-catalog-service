using Microsoft.EntityFrameworkCore;
using RestCatalogService.WebApi.Domain.Interfaces;
using RestCatalogService.WebApi.Features.Categories.Add;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Categories;
using RestCatalogService.WebApi.Persistence.EntityFrameworkCore.Common;

namespace RestCatalogService.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, SqlServerCategoryRepository>();

        services.AddDbContext<RestCatalogServiceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RestCatalogServiceSqlServerConnection"));
        });

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var dbContext = serviceProvider.GetRequiredService<RestCatalogServiceDbContext>();
            dbContext.Database.Migrate();
        }

        services.AddScoped<AddCategoryHandler>();

        return services;
    }
}
