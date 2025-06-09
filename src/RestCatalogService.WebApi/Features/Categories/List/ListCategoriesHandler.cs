using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Categories.List;

public class ListCategoriesHandler
{
    private readonly ICategoryRepository _repo;
    public ListCategoriesHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<IReadOnlyList<Category>> Handle()
    {
        return await _repo.ListAsync();
    }
}