using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsMoviePurchased(int MovieId, int UserId)
        {
            var ispurchase = await _dbContext.Purchases.FirstOrDefaultAsync(p => (p.UserId == UserId) && (p.MovieId == MovieId));
            if (ispurchase == null) { return false; }
            else { return true; }
        }
    }
}
