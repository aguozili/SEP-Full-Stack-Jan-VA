using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {

            //wether the uesr is loged in
            //get the user id 
            // send the user id to database to get all the movies user purchased.


            //cookie based authentication (browser)
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                //get the user id from cookies/claims
                var userId =Convert.ToInt32( HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                //send this userid to userservice and get the movies user purchased from puchase table

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BuyMovie()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> FavoriteMovies()
        {
            return View();
        }   

}
}
