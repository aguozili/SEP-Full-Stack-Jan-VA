using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // account/register => Get
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        //send the data back
        [HttpPost]
        public  async Task<IActionResult> Register(RegisterModel model)
        {

            // save the password and account with salt!
            var user = await _accountService.CreateUser(model);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var userLogedIn = await _accountService.ValidateUser(model.Email, model.Password);
            if (userLogedIn)
            {

                // create an authentication cookie and store some claims information in the cookie
                return LocalRedirect("~/");
            }
            else
            {
                return View();
            }
        }
    }
}
