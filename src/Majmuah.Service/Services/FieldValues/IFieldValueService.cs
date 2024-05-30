using Majmuah.Domain.Entities.Fields;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.FieldValues;

public interface IFieldValueService
{
    ValueTask<FieldValue> CreateAsync(FieldValue fieldValue);
    ValueTask<FieldValue> UpdateAsync(long id, FieldValue fieldValue);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<FieldValue> GetByIdAsync(long id);
    ValueTask<IEnumerable<FieldValue>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}