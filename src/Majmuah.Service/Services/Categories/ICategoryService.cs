using Majmuah.Domain.Entities.Categories;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Categories;

public interface ICategoryService
{
    ValueTask<Category> CreateAsync(Category category);
    ValueTask<Category> UpdateAsync(long id, Category category);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Category> GetByIdAsync(long id);
    ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}