using Majmuah.Domain.Enums;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.ItemTags;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.ItemTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class ItemTagsController(IItemTagApiService itemTagApiService) : BaseController
{
    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(ItemTagCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await itemTagApiService.PostAsync(createModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, ItemTagUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await itemTagApiService.PutAsync(id, updateModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await itemTagApiService.DeleteAsync(id)
        });
    }

    [AllowAnonymous]
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await itemTagApiService.GetAsync(id)
        });
    }

    [AllowAnonymous]
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
            Data = await itemTagApiService.GetAsync(@params, filter, search)
        });
    }
}
