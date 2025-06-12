using ErrorOr;
using RestCatalogService.WebApi.Domain.Interfaces;

namespace RestCatalogService.WebApi.Features.Items.Update;

public class UpdateItemHandler
{
    private readonly IItemRepository _itemRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateItemHandler(IItemRepository itemRepository, ICategoryRepository categoryRepository)
    {
        _itemRepository = itemRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateItemCommand command)
    {
        var maybeExistingItem = await _itemRepository.FindByIdAsync(command.Id);
        if (maybeExistingItem is null)
        {
            return Error.NotFound(description: $"The item with id {command.Id} doesn't exist");
        }

        if (command.CategoriesIds.Count != command.CategoriesIds.Distinct().Count())
        {
            return Error.Conflict(description: "Duplicated categories present");
        }

        var doesAllCategoriesExists = await _categoryRepository.AreAllPresentAsync(command.CategoriesIds);
        if (!doesAllCategoriesExists)
        {
            return Error.NotFound(description: "Some category doesn't exist");
        }

        maybeExistingItem.Update(command.Name, command.CategoriesIds);

        await _itemRepository.UpdateAsync(maybeExistingItem);
        return Result.Updated;
    }
}