using Application.CQRS.Users.Commands;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Repositories;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var existingUser = await _userRepository.GetUserByEmailAsync(request.User.Email);
        if (existingUser != null)
        {
            return Result<int>.Failure("User with this email already exists.");
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

        await _userRepository.RegisterAsync(user); 
        return Result<int>.Success(user.Id); 
    }
}
