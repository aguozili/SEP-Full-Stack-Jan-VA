using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShopAPI.Services;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private  ICurrentUser _currentUser;
        private  IUserService _userService;
        private  IMovieService _movieService;


        public UserController(ICurrentUser currentUser, IUserService userService, IMovieService movieService = null)
        {
            _currentUser = currentUser;
            _userService = userService;
            _movieService = movieService;
        }


        [Route("purchases")]
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {

            //var userId = _currentUser.UserId;
            //var purchaseDetails = await _userService.GetAllPurchasesForUser(userId);
            //if(purchaseDetails == null)
            //{
            //    return NotFound();
            //}
            //return Ok(purchaseDetails);

            return Ok();
            
        }


        [Route("favorite")]
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUser.UserId;
            var favoriteList = await _userService.GetAllFavoritesForUser(userId);
            if(favoriteList == null)
            {
                return NotFound();
            }
            return Ok(favoriteList);
        }


        [Route("purchase-movie")]
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
            if (purchase == null)
            {
                return BadRequest();
            }
            return Ok(purchase);
        }
    }
}
