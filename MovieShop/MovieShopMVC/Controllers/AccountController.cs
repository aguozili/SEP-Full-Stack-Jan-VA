using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
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
            return View();
        }
    }
}
