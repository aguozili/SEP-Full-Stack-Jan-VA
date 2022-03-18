using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                //400 bad request
                return BadRequest();
            }
            var user = await _accountService.CreateUser(model);
            if(user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //check the email/pw

            var user = await _accountService.ValidateUser(model.Email, model.Password);
            if(user == null)
            {
                return Unauthorized(new {error = "please verify email/password"});
            }


            var token = GenerateToken(user);
            return Ok(new { token = token });


        }

        private string GenerateToken(LoginResponseModel user)
        {
            //create the claims

            var claims = new List<Claim>
            {
                new Claim( ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.DateOfBirth.ToShortDateString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new("language", "en")
            };

            //add any role claims to the above claims

            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            //check if user has any roles
            //if (user.Roles.Any())
            //{
                
            //}


            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);


            //create the token with a seret signature
            //expiration date

            var securityKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var expirationTime = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("ExpirationHours"));
            var tokenHandler = new JwtSecurityTokenHandler();


            //describe the contents of token

            var token = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = expirationTime,
                SigningCredentials = credentials,
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"]
            };

            var encodedJWT = tokenHandler.CreateToken(token);
            return  tokenHandler.WriteToken(encodedJWT);


        }
    }
}
