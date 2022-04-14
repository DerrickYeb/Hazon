using System.Text.Json.Serialization;
using Hazon.DAL.Application.Abstractions;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.SharedDto.AccountDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HazonApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _authentication;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthenticationRepository authentication, ILogger<AuthController> logger)
        {
            _authentication = authentication;
            _logger = logger;
        }
        [HttpPost("user/username/password/login")]
        public async Task<IActionResult> UsernamePasswordLogin(AuthInputModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(model);

                var result = await _authentication.AuthenticateUserAsync(model);
                return Ok(new
                {
                    IsSuccessful = true,
                    Data = result,
                    Message = "User login successfully"
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e,"An error occurred while executing {MethodName}-{Input} {Traces}",nameof(UsernamePasswordLogin),
                    JsonConvert.SerializeObject(model),e.StackTrace);
                return Ok(new
                {
                    IsSuccessful = false,
                    Error = e.Message,
                    Message = "An error occurred accessing the server",
                    StatusCode = 500
                });
            }
        }
        [HttpPost("user/register")]
        public async Task<IActionResult> RegisterUser(UserInputModel user)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(user);

                var result = await _authentication.RegisterUserAsync(user);
                return Ok(new
                {
                    IsSuccesful = true,
                    Data = result,
                    Message = "User registered successfully"
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while executing {MethodName}-{Input} {Traces}", nameof(RegisterUser),
                    JsonConvert.SerializeObject(user), e.StackTrace);
                return Ok(new
                {
                    IsSuccessful = false,
                    Error = e.Message,
                    Message = "An error occurred accessing the server",
                    StatusCode = 500
                });
            }
        }
    }
}
