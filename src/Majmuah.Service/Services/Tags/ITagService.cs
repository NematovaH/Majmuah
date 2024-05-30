using Majmuah.Domain.Entities.Tags;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Tags;

public interface ITagService
{
    ValueTask<Tag> CreateAsync(Tag tag);
    ValueTask<Tag> UpdateAsync(long id, Tag tag);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Tag> GetByIdAsync(long id);
    ValueTask<IEnumerable<Tag>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}