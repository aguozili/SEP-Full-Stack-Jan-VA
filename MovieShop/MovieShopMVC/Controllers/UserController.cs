using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;


        public UserController(ICurrentUser currentUser, IUserService userService, IMovieService movieService = null)
        {
            _currentUser = currentUser;
            _userService = userService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Purchases()
        {

            var userId = _currentUser.UserId;
            var purchaseDetails = await _userService.GetAllPurchasesForUser(userId);
            return View(purchaseDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUser.UserId;
            var favoriteList = await _userService.GetAllFavoritesForUser(userId);
            return View(favoriteList);
        }

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            var userId = _currentUser.UserId;
            var movieprice = await _movieService.GetMoviePrice(movieId);
            var purchaseModel = new PurchaseRequestModel
            {
                MovieID = movieId,
                UserId = userId,
                PurchaseNumber = Guid.NewGuid(),
                PurchasedDate = DateTime.Now,
                Price = movieprice
            };
            var purchase = await _userService.PurchaseMovie(purchaseModel, userId);
            return RedirectToAction("Purchases");
        }



        [HttpGet]
        public async Task<IActionResult> FavoriteMovies()
        {
            return View();
        }   

}
}
