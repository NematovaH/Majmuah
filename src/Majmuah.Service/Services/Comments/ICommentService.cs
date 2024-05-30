using Majmuah.Domain.Entities.Comments;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Comments;

public interface ICommentService
{
    ValueTask<Comment> CreateAsync(Comment comment);
    ValueTask<Comment> UpdateAsync(long id, Comment comment);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Comment> GetByIdAsync(long id);
    ValueTask<IEnumerable<Comment>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}