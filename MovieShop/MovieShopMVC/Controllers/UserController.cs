using Microsoft.AspNetCore.Mvc;

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
