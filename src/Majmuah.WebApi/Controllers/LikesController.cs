using Majmuah.Domain.Enums;
using Majmuah.WebApi.ApiServices.Likes;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.Likes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;


[CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
public class LikesController(ILikeApiService fieldApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(LikeCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.PostAsync(createModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.DeleteAsync(id)
        });
    }

    [AllowAnonymous]
    [HttpGet("user/{userId:long}")]
    public async ValueTask<IActionResult> GetAllByUserIdAsync(long userId)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.GetAllAByUserIdsync(userId)
        });
    }

    [AllowAnonymous]
    [HttpGet("item/{itemId:long}")]
    public async ValueTask<IActionResult> GetAllByItemIdAsync(long itemId)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.GetAllAByItemIdsync(itemId)
        });
    }
}