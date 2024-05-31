﻿using Majmuah.Domain.Enums;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.Fields;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.Fields;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;


[CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
public class FieldsController(IFieldApiService fieldApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(FieldCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.PostAsync(createModel)
        });
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, FieldUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await fieldApiService.PutAsync(id, updateModel)
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
