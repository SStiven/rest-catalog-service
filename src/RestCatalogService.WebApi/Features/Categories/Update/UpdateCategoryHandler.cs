using ErrorOr;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Categories.Update;

public class UpdateCategoryHandler
{
    private readonly ICategoryRepository _repo;
    public UpdateCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<ErrorOr<Guid>> Handle(UpdateCategoryCommand command)
    {
        var maybeCategory = await _repo.FindByIdAsync(command.Id);
        if (maybeCategory is null)
        {
            return Error.NotFound("Category not found");
        }

        maybeCategory.UpdateName(command.Name);
        await _repo.UpdateAsync(maybeCategory);
        return maybeCategory.Id;
    }
}