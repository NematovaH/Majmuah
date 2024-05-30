using AutoMapper;
using Majmuah.Domain.Entities.Likes;
using Majmuah.Service.Services.Likes;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.Likes;
using Majmuah.WebApi.Validators.Likes;

namespace Majmuah.WebApi.ApiServices.Likes;

public class LikeApiService(
    IMapper mapper,
    ILikeService likeService,
    LikeCreateModelValidator createModelValidator) : ILikeApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await likeService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<LikeViewModel>> GetAllAByUserIdsync(long id)
    {
        var likes = await likeService.GetAllAByUserIdsync(id);
        return mapper.Map<IEnumerable<LikeViewModel>>(likes);
    }

    public async ValueTask<IEnumerable<LikeViewModel>> GetAllAByItemIdsync(long id)
    {
        var likes = await likeService.GetAllAByItemIdsync(id);
        return mapper.Map<IEnumerable<LikeViewModel>>(likes);
    }

    public async ValueTask<LikeViewModel> PostAsync(LikeCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var mappedItemTag = mapper.Map<Like>(createModel);
        var createdItemTag = await likeService.CreateAsync(mappedItemTag);
        return mapper.Map<LikeViewModel>(createdItemTag);
    }
}