using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    public class MoviesController: Controller
    {
        private IMovieService _movieService;
        private readonly ICurrentUser _currentUser;
        private readonly IPurchaseRepository _purchaseRepository;


        public MoviesController(IMovieService movieService, ICurrentUser currentUser, IPurchaseRepository purchaseRepository)
        {
            _movieService = movieService;
            _currentUser = currentUser;
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            if (_currentUser.isAuthenticated)
            {
                var userId = _currentUser.UserId;
                bool ispurchased = await _purchaseRepository.IsMoviePurchased(Id, userId);

                if (ispurchased)
                {
                    ViewBag.MoviePurchased = true;
                } 
            }
            else
            {
                ViewBag.MoviePurchased = false;
            };

            //Movie service with details
            //pass the movie detail data to view
            var movieDetails = await _movieService.GetMovieDetails(Id);
            return View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View("PagedMovies",pagedMovies);
        }

    }
}
