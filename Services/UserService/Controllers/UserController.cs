namespace Mausam.Services.UserService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Mausam.Services.UserService.Interfaces;
    using Mausam.Services.UserService.Models;

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserCheckin _userService;

        public UserController(IUserCheckin userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationModel model)
        {
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel model)
        {
            return Ok("Login successful");
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] PasswordResetModel model)
        {
            return Ok("ForgotPassword successful");
        }

        [HttpPost("google-login")]
        public IActionResult GoogleLogin([FromBody] GoogleLoginModel model)
        {
            return Ok("GoogleLogin successful");
        }
    }
}
