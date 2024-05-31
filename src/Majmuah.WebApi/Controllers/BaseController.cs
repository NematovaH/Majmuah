﻿using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomAuthorize]
public class BaseController : ControllerBase
{
    public string UserPhone => HttpContext?.User?.FindFirst("Phone")?.Value;
    public long GetUserId => Convert.ToInt64(HttpContext?.User?.FindFirst("Id")?.Value);
}