using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService (ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetById(id);

            var castDetails = new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
 
            };

            castDetails.Movies = new List<MovieModel>();
            foreach (var movie in cast.MovieCasts)
            {
                castDetails.Movies.Add(new MovieModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl=movie.Movie.PosterUrl,

                });
            }

            return castDetails;
        }
    }
}
