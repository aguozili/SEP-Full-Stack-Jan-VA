using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // call movierepository (call the database with Dapper or EF Core)
            var movies = new List<MovieCardModel>()
            {
                new MovieCardModel{ Id = 1, PosterUrl ="", Title =""},
                new MovieCardModel{ Id = 1, PosterUrl ="", Title =""},
                new MovieCardModel{ Id = 1, PosterUrl ="", Title =""},
                new MovieCardModel{ Id = 1, PosterUrl ="", Title =""},
                new MovieCardModel{ Id = 1, PosterUrl ="", Title =""},

            };

            return movies;
        }
    }
}
