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
        //Task<List<MovieCardModel>> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        //Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<PurchaseDetailsModel> GetAllPurchasesForUser(int id);

        Task<FavoriteListModel> GetAllFavoritesForUser(int id);

    }
}
