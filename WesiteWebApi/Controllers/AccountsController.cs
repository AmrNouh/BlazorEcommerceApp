using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Website.Shared.DTOs;
using WesiteWebApi.Models;

namespace WesiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ResponseDto _response;


        public AccountsController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _response = new ResponseDto();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (loginUserDto is null || !ModelState.IsValid)
            {
                _response.IsSuccessfulOperation = false;
                _response.Errors = ModelState.Values.SelectMany(e => e.Errors.Select(error => error.ErrorMessage));
                return BadRequest(_response);
            }

            ApplicationUser? user = await _userManager.FindByNameAsync(loginUserDto.UserName);
            if (user is not null && await _userManager.CheckPasswordAsync(user, loginUserDto.Password))
            {
                IList<string>? userRoles = await _userManager.GetRolesAsync(user);
                List<Claim>? authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, loginUserDto.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (string? userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                SymmetricSecurityKey? authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                JwtSecurityToken? token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    username = user.UserName,
                    Role = userRoles.FirstOrDefault(),
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            if (userDto is null || !ModelState.IsValid)
            {
                List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError>? modelErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                _response.IsSuccessfulOperation = false;
                foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError? error in modelErrors)
                {
                    _response.Errors.ToList().Add(error.ErrorMessage);
                }
                return BadRequest(_response);
            }

            ApplicationUser? userNameExists = await _userManager.FindByNameAsync(userDto.UserName);
            if (userNameExists != null)
            {
                return BadRequest("User already Exists");
            }
            ApplicationUser? emailExists = await _userManager.FindByEmailAsync(userDto.Email);
            if (emailExists != null)
            {
                return BadRequest("Email already Exists");
            }

            ApplicationUser user = new()
            {
                Email = userDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userDto.UserName,
            };

            IdentityResult? result = await _userManager.CreateAsync(user, userDto.Password);

            if (result is not null)
            {
                if (!result.Succeeded)
                {
                    _response.IsSuccessfulOperation = false;
                    _response.Errors = result.Errors.Select(e => e.Description);
                    return BadRequest(_response);
                }
            }

            return Ok("User Created Successfully");
        }

    }
}
