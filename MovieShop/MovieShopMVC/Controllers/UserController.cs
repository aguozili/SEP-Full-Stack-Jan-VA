using ApplicationCore.Contracts.Services;
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

        
        public UserController(ICurrentUser currentUser, IUserService userService)
        {
            _currentUser = currentUser;
            _userService = userService;
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
