﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        


        public async Task<int> CreateUser(RegisterModel model)
        {
            //registration process
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                throw new Exception("Email already  registered, try to login");
            }

            //continue with registration
            //generate a random salt
            //hash the password with salt

            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(model.Password, salt);

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = model.DateOfBirth

            };

            //save the user to User table

            var createdUser = await _userRepository.Add(user);
            return createdUser.Id;


        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("username and password in valud");
            }

            var hashedPassword = GetHashedPassword(password, user.Salt);
            if (hashedPassword == user.HashedPassword)
            {
                return true;
            }

            return false;
        }

        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password,
            Convert.FromBase64String(salt),
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));
            return hashed;
        }
    }
}
