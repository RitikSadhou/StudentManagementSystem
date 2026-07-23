using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthService> _logger;
        public AuthController(IAuthService authService, ILogger<AuthService> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (!result)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Username already exists."
                });
            }
            _logger.LogInformation(  "User {Username} registered successfully.",  dto.Username);
            return Ok(new
            {
                Success = true,
                Message = "User registered successfully."
            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
            {
                _logger.LogWarning( "Invalid login attempt for user {Username}.",dto.Username);
                return Unauthorized(new
                {
                    Success = false,
                    Message = "Invalid username or password."
                });
            }

            return Ok(new
            {
                Success = true,
                Token = token
            });
        }
    }
}
