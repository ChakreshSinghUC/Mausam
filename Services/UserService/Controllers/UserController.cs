namespace Mausam.Services.UserService.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Mausam.Services.UserService.Models;

    [AllowAnonymous]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, PasswordHash = model.LoginPassword };
                var result = await _userManager.CreateAsync(user, model.LoginPassword);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok("Registration and login successful");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.LoginPassword, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Redirect to the returnUrl or a default page
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("api/users/login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("api/users/process-login")]
        public IActionResult ProcessLogin()
        {
            // Perform login logic
            // For now, just return a success message
            return Ok(new { Message = "ProcessLogin successful" });
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
