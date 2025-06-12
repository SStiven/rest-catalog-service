using ErrorOr;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Items.Delete;

public class DeleteItemHandler
{
    private readonly IItemRepository _repo;

    public DeleteItemHandler(IItemRepository repo)
    {
        _repo = repo;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteItemCommand command)
    {
        var maybeItem = await _repo.FindByIdAsync(command.Id);
        if (maybeItem is null)
        {
            return Error.NotFound();
        }

        await _repo.DeleteAsync(maybeItem);
        return Result.Deleted;
    }
}