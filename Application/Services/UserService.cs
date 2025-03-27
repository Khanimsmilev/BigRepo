using Application.CQRS.Users.DTOs;
using Application.CQRS.Users.DTOs;
using Application.Services;
using Domain.Entities;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshtokenRepository _refreshTokenRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> RegisterUserAsync(RegisterDto request)
        {
            var salt = GenerateSalt();
            var hashedPassword = HashPassword(request.Password, salt);

            var user = new User
            {
                FirstName = request.Username, // Username-i FirstName kimi qeyd etdim, muveqqeti, deyisecem
                Email = request.Email,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                ProfilePictureUrl = "",
                Role = Domain.Enums.UserRoles.User
            };

            await _userRepository.RegisterAsync(user);
            return user;
        }

        public async Task<User?> ValidateUserAsync(LoginDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null) return null;

            var hashedInputPassword = HashPassword(request.Password, user.PasswordSalt);
            if (user.PasswordHash != hashedInputPassword) return null;

            return user;
        }

        public async Task<string?> RefreshTokenAsync(RefreshTokenDto request)
        {
            return "NEW_ACCESS_TOKEN";
        }

        public async Task<bool> UpdateRefreshTokenAsync(int userId, string refreshToken)
        {

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;


            var newRefreshToken = new RefreshToken
            {
                UserId = userId,                         
                Token = refreshToken,                   
                ExpirationDate = DateTime.UtcNow.AddDays(7) 
            };


            await _refreshTokenRepository.SaveRefreshToken(newRefreshToken);

            return true;
        }


        public Task LogoutUserAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDto request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            user.FirstName = request.FirstName;
            user.Email = request.Email;
            user.ProfilePictureUrl = request.ProfilePictureUrl;
            user.Bio = request.Bio;

            await _userRepository.UpdateAsync(user);
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepository.RemoveAsync(id);
            return true;
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hash = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
