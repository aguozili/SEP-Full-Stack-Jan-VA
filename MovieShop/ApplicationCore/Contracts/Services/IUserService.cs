using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {


        //Favorite
        Task<FavoriteListModel> GetAllFavoritesForUser(int id);
        Task<int> AddFavorite(FavoriteRequestModel model);
        Task<int> RemoveFavorite(FavoriteRequestModel model);
        Task<int> FavoriteExists(int userId, int movieId);


        //Review
        Task<UserReviewModel> GetAllReviewsByUser(int id);
        Task<int> AddMovieReview(ReviewRequestModel model);
        Task<int> UpdateMovieReview(ReviewRequestModel model);
        Task<int> DeleteMovieReview(ReviewRequestModel model);


        //Purchase
        Task<UserPurchaseModel> GetAllPurchasesForUser(int id);
        Task<int> PurchaseMovie(PurchaseRequestModel model, int id);
        Task<PurchaseDetailsModel> GetPurchasesDetails(int userId, int movieId);

        Task<bool> IsMoviePurchased(PurchaseRequestModel model, int id);

    }
}
