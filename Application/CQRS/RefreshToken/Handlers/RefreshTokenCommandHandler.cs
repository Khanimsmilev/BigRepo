using Application.CQRS.RefreshToken.Commands;
using Application.CQRS.RefreshToken.DTOs;
using Application.Services;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.RefreshToken.Handlers;
public class RefreshTokenCommandHandler(
    IUnitOfWork unitOfWork,
    IConfiguration configuration
) : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponseDto>>
{
    public async Task<Result<RefreshTokenResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var principal = TokenService.GetPrincipalFromExpiredToken(request.AccessToken, configuration);
        if (principal == null)
            return Result<RefreshTokenResponseDto>.Failure("Invalid access token.");

        var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out int userId))
            return Result<RefreshTokenResponseDto>.Failure("Invalid user info in token.");

        var storedToken = await unitOfWork.RefreshTokenRepository.GetStoredRefreshToken(request.RefreshToken);
        if (storedToken == null || storedToken.IsRevoked || storedToken.UserId != userId || storedToken.ExpiryDate < DateTime.UtcNow)
            return Result<RefreshTokenResponseDto>.Failure("Invalid or expired refresh token.");

        var user = await unitOfWork.UserRepository.GetByIdAsync(userId);
        if (user == null)
            return Result<RefreshTokenResponseDto>.Failure("User not found.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        var newAccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.CreateToken(claims, configuration));
        var expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:AccessTokenExpirationMinutes"]!));

        return Result<RefreshTokenResponseDto>.Success(new RefreshTokenResponseDto
        {
            AccessToken = newAccessToken,
            ExpiresAt = expires
        });
    }
}