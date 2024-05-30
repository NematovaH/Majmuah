using Majmuah.Domain.Entities.Collections;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Collections;

public interface ICollectionService
{
    ValueTask<Collection> CreateAsync(Collection collection);
    ValueTask<Collection> UpdateAsync(long id, Collection collection);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Collection> GetByIdAsync(long id);
    ValueTask<IEnumerable<Collection>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}