using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Likes;

namespace Majmuah.WebApi.ApiServices.Likes;

public interface ILikeApiService
{
    ValueTask<LikeViewModel> PostAsync(LikeCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<LikeViewModel>> GetAllAByUserIdsync(long UserId);
    ValueTask<IEnumerable<LikeViewModel>> GetAllAByItemIdsync(long ItemId);
}