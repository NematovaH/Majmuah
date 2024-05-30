using Majmuah.Service.Configurations;
using Majmuah.WebApi.Models.Comments;

namespace Majmuah.WebApi.ApiServices.LessonComments;

public interface ICommentApiService
{
    ValueTask<CommentViewModel> PostAsync(CommentCreateModel createModel);
    ValueTask<CommentViewModel> PutAsync(long id, CommentUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CommentViewModel> GetAsync(long id);
    ValueTask<IEnumerable<CommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null);
}