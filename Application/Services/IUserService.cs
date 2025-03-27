using Application.CQRS.Users.DTOs;
using Application.CQRS.Users.DTOs;
using Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services;

public interface IUserService
{
    Task<User?> RegisterUserAsync(RegisterDto request);
    Task<User?> ValidateUserAsync(LoginDto request);
    Task<string?> RefreshTokenAsync(RefreshTokenDto request);
    Task<bool> UpdateRefreshTokenAsync(int userId, string refreshToken);
    Task LogoutUserAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> UpdateUserAsync(int id, UpdateUserDto request);
    Task<bool> DeleteUserAsync(int id);
}
