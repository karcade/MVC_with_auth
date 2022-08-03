using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.BussinessLogic.Services.Interfaces;
using WebApp.Common.ViewModels;
using WebApp.Model.DatabaseModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userService.Create(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterUser(RegisterUser registerUser)
        {
            _userService.Register(registerUser);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(SignInUser signinUser)
        {
            _userService.Login(signinUser);
            return Ok();
        }
    }
}
