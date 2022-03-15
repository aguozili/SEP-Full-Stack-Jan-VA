using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public Task<bool> CreateUser(RegisterModel model)
        {
           //registration process

            throw new NotImplementedException();
        }

        public Task<bool> ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
