using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services;

public static class TokenService
{
    public static JwtSecurityToken CreateToken(List<Claim> authClaims, IConfiguration configuration)
    {
        var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            claims: authClaims,
            expires: DateTime.UtcNow.AddMinutes(
                Double.Parse(configuration["JWT:AccessTokenExpirationMinutes"]!)
            ),
            signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
        );
        return token;
    }

    public static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64]; // Daha təhlükəsiz üçün 64 byte
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public static ClaimsPrincipal? GetPrincipalFromExpiredToken(string token, IConfiguration configuration)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false, // Expired token üçün false olmalıdır
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:ValidIssuer"],
            ValidAudience = configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || jwtSecurityToken.Header.Alg != SecurityAlgorithms.HmacSha256)
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}
