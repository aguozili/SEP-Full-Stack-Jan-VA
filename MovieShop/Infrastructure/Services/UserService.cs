using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> AddFavorite(FavoriteRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMovieReview(ReviewRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMovieReview(ReviewRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> FavoriteExists(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteListModel> GetAllFavoritesForUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var favoriteList = new FavoriteListModel
            {
                UserId = user.Id
            };

            favoriteList.favorites = new List<FavoriteModel>();
            foreach (var favorite in user.Favorites)
            {
                favoriteList.favorites.Add(new FavoriteModel
                {
                    MovieId = favorite.MovieId,
                    UserId = favorite.UserId,
                    MovieTitle = favorite.Movie.Title,
                    PosterUrl = favorite.Movie.PosterUrl
                });
            };

            return favoriteList;
        }

        public async Task<UserPurchaseModel> GetAllPurchasesForUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var puchaseDetails = new UserPurchaseModel
            {
                UserId = user.Id
            };
            puchaseDetails.Purchases = new List<PurchaseModel>();
            foreach (var purchase in user.Purchases)
            {
                puchaseDetails.Purchases.Add(new PurchaseModel
                {
                    Id = purchase.Id,
                    UserId = purchase.UserId,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    PurchaseNumber = purchase.PurchaseNumber,
                    TotalPrice = purchase.TotalPrice,
                    MovieId = purchase.MovieId,
                    MovieTitle = purchase.Movie.Title,
                    PosterUrl = purchase.Movie.PosterUrl
                });
            }

            

            

            return puchaseDetails;
        }

        public async Task<UserReviewModel> GetAllReviewsByUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var reviewList = new UserReviewModel
            {
                Id = user.Id
            };

            reviewList.Reviews = new List<ReviewModel>();
            foreach (var review in user.Reviews)
            {
                reviewList.Reviews.Add(new ReviewModel
                {
                    MovieId = review.MovieId,
                    UserId = review.UserId,
                    MovieTitle = review.Movie.Title,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating,
                    PosterUrl = review.Movie.PosterUrl
                });
            };

            return reviewList;
        }

        public Task<PurchaseDetailsModel> GetPurchasesDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsMoviePurchased(PurchaseRequestModel model, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> PurchaseMovie(PurchaseRequestModel model, int id)
        {
            var user = await _userRepository.GetById(id);

            var purchase = new Purchase
            {
                UserId = model.UserId,
                MovieId = model.MovieID,
                TotalPrice = model.Price,
                PurchaseDateTime = model.PurchasedDate,
                PurchaseNumber = model.PurchaseNumber
            };

            var makepurhcase = await _userRepository.Add(user);
            return makepurhcase.Id;
        }

        public Task<int> RemoveFavorite(FavoriteRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateMovieReview(ReviewRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
