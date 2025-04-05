using Application.CQRS.Users.Commands;
using Application.CQRS.Users.DTOs;
using Application.Services;
using Common.GlobalResponses.Generics;
using Common.Security;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.Users.Commands.Handlers;
public class LoginUserCommandHandler(
    IUnitOfWork unitOfWork,
    ICustomPasswordHasher passwordHasher,
    IConfiguration configuration
) : IRequestHandler<LoginUserCommand, Result<LoginResponseDto>>
{
    public async Task<Result<LoginResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);
        if (user == null || !user.IsEmailConfirmed)
            return Result<LoginResponseDto>.Failure("Invalid credentials or email not confirmed.");

        var isValidPassword = passwordHasher.VerifyHashedPassword(request.Password, user.PasswordSalt!, user.PasswordHash);
        if (!isValidPassword)
            return Result<LoginResponseDto>.Failure("Invalid credentials.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        var accessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.CreateToken(claims, configuration));
        var refreshToken = TokenService.GenerateRefreshToken();
        var refreshExpiry = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:RefreshTokenExpirationMinutes"]!));

        var refreshTokenEntity = new Domain.Entities.RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
            ExpiryDate = refreshExpiry,
            IsRevoked = false
        };

        await unitOfWork.RefreshTokenRepository.SaveRefreshToken(refreshTokenEntity);
        await unitOfWork.SaveChangesAsync();

        var response = new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExpiry = refreshExpiry
        };

        return Result<LoginResponseDto>.Success(response);
    }
}