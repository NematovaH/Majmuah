using Microsoft.AspNetCore.Mvc;

namespace Majmuah.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomAuthorize]
public class BaseController : ControllerBase
{ }