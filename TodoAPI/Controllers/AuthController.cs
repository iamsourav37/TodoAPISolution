using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTOs.Account;
using TodoAPI.Utility;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiResponse _apiResponse;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configurationManager)
        {
            this._userManager = userManager;
            this._configuration = configurationManager;
            this._apiResponse = new ApiResponse();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                _apiResponse.StatusCode = 400;
                _apiResponse.Errors = ModelState.Values
                        .SelectMany(value => value.Errors)
                        .Select(error => error.ErrorMessage)
                        .ToArray();

                return BadRequest(_apiResponse);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            _apiResponse.StatusCode = 201;
            _apiResponse.Data = "User registered successfully";
            return Ok(_apiResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                _apiResponse.StatusCode = 401;
                _apiResponse.Errors = ["Invalid Credentials", "Email and Password is invalid !"];
                return Unauthorized(_apiResponse);
            }

            var token = GenerateJwtToken(user);
            _apiResponse.StatusCode = 200;
            _apiResponse.Data = token;
            return Ok(_apiResponse);
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
