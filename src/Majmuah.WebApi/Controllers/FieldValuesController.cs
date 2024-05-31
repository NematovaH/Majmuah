using Majmuah.Domain.Enums;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.FieldValues;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.FieldValues;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class FieldValuesController(IFieldValueApiService fieldValueApiService) : BaseController
{
    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(FieldValueCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldValueApiService.PostAsync(createModel)
        });
    }

    [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, FieldValueUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldValueApiService.PutAsync(id, updateModel)
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
            Data = await fieldValueApiService.DeleteAsync(id)
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
            Data = await fieldValueApiService.GetAsync(id)
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
            Data = await fieldValueApiService.GetAsync(@params, filter, search)
        });
    }
}
