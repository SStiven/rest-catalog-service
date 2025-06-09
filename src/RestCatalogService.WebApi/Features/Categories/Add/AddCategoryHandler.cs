using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Categories.Add;

public class AddCategoryHandler
{
    private readonly ICategoryRepository _repo;
    public AddCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(AddCategoryCommand command)
    {
        var cat = new Category(command.Name);
        await _repo.AddAsync(cat);
        return cat.Id;
    }
}