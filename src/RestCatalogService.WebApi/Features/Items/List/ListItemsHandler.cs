using ErrorOr;
using RestCatalogService.WebApi.Domain;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Items.List;

public class ListItemsHandler
{
    private readonly IItemRepository _repo;

    public ListItemsHandler(IItemRepository repo)
    {
        _repo = repo;
    }

    public async Task<ErrorOr<IEnumerable<Item>>> Handle(Guid? categoryId, int page, int size)
    {
        if (page < 1)
        {
            return Error.Validation(description: $"{nameof(page)} should be >= 1");
        }

        if (size <= 0)
        {
            return Error.Validation(description: $"{nameof(page)} should be >= 0");
        }

        var specification = new ItemsByCategorySpec(categoryId);
        return await _repo.ListAsync(specification, page, size);
    }
}