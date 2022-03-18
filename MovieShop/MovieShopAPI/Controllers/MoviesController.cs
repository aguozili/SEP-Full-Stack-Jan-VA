using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    //Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //in REST pattern we dont specify the http verbs in the url
        //API: JSON data, no view

        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // create action method


        // api/movie/{id}
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            //convert movie data to JSON format
            if (movie == null)
            {
                return NotFound( new {error = $"Movie Not Found for id: {id}"});
            }
            return Ok(movie);

        }

        [Route("genres/{genresId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetGenres(int genresId, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByGenrePagination(genresId, pageSize, pageNumber);

            //convert movie data to JSON format
            if (pagedMovies == null)
            {
                return NotFound(new { error = $"genres Not Found for id: {genresId}" });
            }
            return Ok(pagedMovies);

        }



    }
}
