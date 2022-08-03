using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.BussinessLogic.Services.Interfaces;
using WebApp.Common.ViewModels.Auth;
using WebApp.Model.DatabaseModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("generate token")]
        public IActionResult Post([FromBody] User model)
        {
            return Ok(_authService.GenerateToken(model));
        }

        [AllowAnonymous]
        [HttpPost("get token")]
        public IActionResult Get([FromBody] User model)
        {
            return Ok(_authService.GetToken(model));
        }
    }
}
