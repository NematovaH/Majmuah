using Majmuah.Domain.Entities.Fields;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Fields;

public interface IFieldService
{
    ValueTask<Field> CreateAsync(Field field);
    ValueTask<Field> UpdateAsync(long id, Field field);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Field> GetByIdAsync(long id);
    ValueTask<IEnumerable<Field>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}