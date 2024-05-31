using Majmuah.Domain.Enums;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.Collections;
using Majmuah.WebApi.Models.Collections;
using Majmuah.WebApi.Models.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class CollectionsController(ICollectionApiService collectionApiService) : BaseController
{
    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(CollectionCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await collectionApiService.PostAsync(createModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, CollectionUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await collectionApiService.PutAsync(id, updateModel)
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
            Data = await collectionApiService.DeleteAsync(id)
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
            Data = await collectionApiService.GetAsync(id)
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
            Data = await collectionApiService.GetAsync(@params, filter, search)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPost("pictures/{id:long}")]
    public async ValueTask<IActionResult> UploadPictureAsync(long id, IFormFile file)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await collectionApiService.UploadPictureAsync(id, file)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpDelete("pictures/{id:long}")]
    public async ValueTask<IActionResult> DeletePictureAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await collectionApiService.DeletePictureAsync(id)
        });
    }
}