using Application.CQRS.Users.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LinkedIn_Project.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase 

        //controllerde bezi xetalar var, deyisiklik edecem, helelik yxolamaq ucun yazilib. 
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var user = await _userService.RegisterUserAsync(request);
            if (user == null)
                return BadRequest("User already exists or invalid data.");

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _userService.ValidateUserAsync(request);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var token = TokenService.CreateToken(authClaims, _configuration);
            var refreshToken = TokenService.GenerateRefreshToken();
           
            await _userService.UpdateRefreshTokenAsync(user.Id, refreshToken);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto request)
        {
            var newToken = await _userService.RefreshTokenAsync(request);
            if (newToken == null)
                return Unauthorized("Invalid refresh token.");

            return Ok(newToken);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutUserAsync();
            return Ok(new { Message = "Logged out successfully" });
        }
    }
}
