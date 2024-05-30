using Majmuah.Domain.Entities.Items;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Items;

public interface IItemService
{
    ValueTask<Item> CreateAsync(Item item);
    ValueTask<Item> UpdateAsync(long id, Item item);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Item> GetByIdAsync(long id);
    ValueTask<IEnumerable<Item>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}