using Arcana.WebApi.Controllers;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.Collections;
using Majmuah.WebApi.Models.Collections;
using Majmuah.WebApi.Models.Commons;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

public class CollectionsController(ICollectionApiService collectionApiService) : BaseController
{
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
}
