using Majmuah.Domain.Enums;
using Majmuah.Service.Configurations;
using Majmuah.WebApi.ApiServices.Users;
using Majmuah.WebApi.Models.Commons;
using Majmuah.WebApi.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers
{
    public class UsersController(IUserApiService userApiService) : BaseController
    {
        [AllowAnonymous]
        [HttpPost("admin")]
        public async ValueTask<IActionResult> PostAdminAsync(UserCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.PostAdminAsync(createModel)
            });
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(UserCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.PostUserAsync(createModel)
            });
        }

        [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, UserUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.PutAsync(id, updateModel)
            });
        }

        [CustomAuthorize(nameof(UserRole.Admin))]
        [HttpPut("changeStatus/{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.ChangeUserStatusAsync(id)
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
                Data = await userApiService.DeleteAsync(id)
            });
        }

        [HttpGet("{id:long}")]
        [AllowAnonymous]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.GetAsync(id)
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public async ValueTask<IActionResult> GetAllAsync(
            [FromQuery] PaginationParams @params,
            [FromQuery] Filter filter,
            [FromQuery] string search = null)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.GetAsync(@params, filter, search)
            });
        }

        [CustomAuthorize(nameof(UserRole.Admin), nameof(UserRole.User))]
        [HttpPatch("change-password")]
        public async ValueTask<IActionResult> ChangePasswordAsync([FromQuery] UserChangePasswordModel userChangePasswordModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.ChangePasswordAsync(userChangePasswordModel)
            });
        }

        [CustomAuthorize(nameof(UserRole.Admin))]
        [HttpPatch("remove-adminRole")]
        public async ValueTask<IActionResult> RemoveAdminRoleAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Ok",
                Data = await userApiService.RemoveAdminRoleAsync()
            });
        }
    }
}
