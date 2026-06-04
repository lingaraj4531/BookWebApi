using BookWebApi.Models;
using BookWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginRequest request)
        {
            var user = await _authService.RegisterAsync(request);
            return Ok(new { message = "User registered successfully", user.UserName });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request);

            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { token });
        }
    }
}