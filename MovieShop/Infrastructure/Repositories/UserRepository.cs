using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public override async Task<User> GetById(int id)
        {
            var userDetails = await _dbContext.Users.Include(u => u.UserRoles).ThenInclude(u => u.Role)
                .Include(u => u.Reviews).ThenInclude(u => u.Movie)
                .Include(u => u.Favorites).ThenInclude(u => u.Movie)
                .Include(u => u.Purchases).ThenInclude(u => u.Movie)
                .FirstOrDefaultAsync(u => u.Id == id);
            return userDetails;
        }
    }
}
