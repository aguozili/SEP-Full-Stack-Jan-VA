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
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        public async Task<PurchaseDetailsModel> GetAllPurchasesForUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var puchaseDetails = new PurchaseDetailsModel
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
    }
}
