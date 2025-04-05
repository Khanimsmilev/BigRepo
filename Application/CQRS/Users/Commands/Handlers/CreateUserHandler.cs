/*using Application.CQRS.Users.Commands;
using Application.CQRS.Users.DTOs;
using Application.Services;
using Common.GlobalResponses.Generics;
using Common.Security;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.Users.Commands.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<CreateUserResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    public CreateUserHandler(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<Result<CreateUserResponseDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var existingUser = await _userRepository.GetUserByEmailAsync(request.User.Email);
        if (existingUser != null)
        {
            return Result<CreateUserResponseDto>.Failure("User with this email already exists.");
        }

        var salt = PasswordHasher.GenerateSalt();
        var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.User.Password, salt);


        var user = new User
        {
            FirstName = request.User.FirstName,
            LastName = request.User.LastName,
            Email = request.User.Email,
            PasswordHash = hashedPassword,
            PasswordSalt = salt,
            CreatedDate = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);



        var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.FirstName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    };

        var token = TokenService.CreateToken(authClaims, _configuration);
        var refreshToken = TokenService.GenerateRefreshToken();
        return Result<CreateUserResponseDto>.Success(new CreateUserResponseDto
        {
            UserId = user.Id,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        });
    }

}*/