using Hazon.DAL.Domain.Models.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HazonClient.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = "")
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            var result = await _signInManager.PasswordSignInAsync(login.Username,
                login.Password,login.RememberMe,lockoutOnFailure: false);
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl) && result.Succeeded)
            {
                Redirect(returnUrl);
            }

        

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult EmailPasswordReset()
        {
            return View();
        }
    }
}
