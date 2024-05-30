﻿using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.ItemTags;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.ItemTags;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class ItemTagsController(IItemTagApiService itemTagApiService) : BaseController
{
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
