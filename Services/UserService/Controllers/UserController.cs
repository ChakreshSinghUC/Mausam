namespace Mausam.Services.UserService.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Mausam.Services.UserService.Models;
    using System;

    [AllowAnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {

        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

        //public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public UserController() { }

        // Add a new action method to render the view
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View(); // This assumes you have a corresponding Razor view named "Login.cshtml"
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationModel model)
        {
            return Ok(new { Message = "Register successful" });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model, string returnUrl = null)
        {
            return Ok(new { Message = "Login successful" });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] PasswordResetModel model)
        {
            // Implement password reset logic
            return Ok(new { Message = "ForgotPassword successful" });
        }

        [HttpPost("google-login")]
        public IActionResult GoogleLogin([FromBody] GoogleLoginModel model)
        {
            // Implement Google login logic
            return Ok(new { Message = "GoogleLogin successful" });
        }
    }
}
