using Majmuah.Domain.Entities.Likes;
using Majmuah.Service.Configurations;

namespace Majmuah.Service.Services.Likes;

public interface ILikeService
{
    ValueTask<Like> CreateAsync(Like like);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<Like>> GetAllAByUserIdsync(long userId);
    ValueTask<IEnumerable<Like>> GetAllAByItemIdsync(long itemId);
}