﻿using AutoMapper;
using Majmuah.Domain.Entities.Comments;
using Majmuah.Service.Configurations;
using Majmuah.Service.Services.Comments;
using Majmuah.WebApi.Extensions;
using Majmuah.WebApi.Models.Comments;
using Majmuah.WebApi.Validators.Comments;

namespace Majmuah.WebApi.ApiServices.LessonComments;

public class CommentApiService(
    IMapper mapper,
    ICommentService commentService,
    CommentCreateModelValidator createModelValidator,
    CommentUpdateModelValidator updateModelValidator) : ICommentApiService
{
    public async ValueTask<CommentViewModel> PostAsync(CommentCreateModel createModel)
    {
        await createModelValidator.EnsureValidatedAsync(createModel);
        var createdComment = await commentService.CreateAsync(mapper.Map<Comment>(createModel));
        return mapper.Map<CommentViewModel>(createdComment);
    }

    public async ValueTask<CommentViewModel> PutAsync(long id, CommentUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);
        var updatedComment = await commentService.UpdateAsync(id, mapper.Map<Comment>(updateModel));
        return mapper.Map<CommentViewModel>(updatedComment);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await commentService.DeleteAsync(id);
    }

    public async ValueTask<CommentViewModel> GetAsync(long id)
    {
        var comment = await commentService.GetByIdAsync(id);
        return mapper.Map<CommentViewModel>(comment);
    }

    public async ValueTask<IEnumerable<CommentViewModel>> GetAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var comments = await commentService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<CommentViewModel>>(comments);
    }
}