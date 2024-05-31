using Majmuah.Domain.Enums;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.Tags;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.Tags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class TagsController(ITagApiService fieldApiService) : BaseController
{
    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(TagCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.PostAsync(createModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, TagUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.PutAsync(id, updateModel)
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
            Data = await fieldApiService.DeleteAsync(id)
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
            Data = await fieldApiService.GetAsync(id)
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
            Data = await fieldApiService.GetAsync(@params, filter, search)
        });
    }
}