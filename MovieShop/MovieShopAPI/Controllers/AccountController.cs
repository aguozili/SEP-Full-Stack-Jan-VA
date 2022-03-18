using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

            var user = _accountService.ValidateUser(model.Email, model.Password);
            if(user == null)
            {
                return Unauthorized(new {error = "please verify email/password"});
            }

            return Ok(user);


        }
    }
}
