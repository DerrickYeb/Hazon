using Hazon.DAL.Application.Abstractions;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.SharedDto.AccountDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HazonClient.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAuthenticationRepository _authenticationService;
        public AccountController(IAuthenticationRepository authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public async Task<JsonResult> LoginUser([FromBody]AuthInputModel login)
        {
            var user = await _authenticationService.AuthenticateUserAsync(login);
            if (user == null) return Json("Username or password cannot be null");
            return Json(new
            {
                state = true,
                Message = "Login successfully",
                Data = user
            });
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
