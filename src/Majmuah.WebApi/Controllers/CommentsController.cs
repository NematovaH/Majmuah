using Arcana.WebApi.Controllers;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.LessonComments;
using Majmuah.WebApi.Models.Comments;
using Majmuah.WebApi.Models.Commons;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class CommentsController(ICommentApiService commentApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CommentCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await commentApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, CommentUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await commentApiService.PutAsync(id, updateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await commentApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await commentApiService.GetAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams @params,
        [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await commentApiService.GetAsync(@params, filter, search)
        });
    }
}
