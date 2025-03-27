using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Repository.Repositories;

namespace Application.CQRS.Users.Commands.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UpdateUserHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.User.Id);
            if (user == null)
                return Result<int>.Failure(new List<string> { "User not found or already deleted" });


            user.FirstName = request.User.FirstName ?? user.FirstName;
            user.LastName = request.User.LastName ?? user.LastName;
            user.Email = request.User.Email ?? user.Email;
            user.ProfilePictureUrl = request.User.ProfilePictureUrl ?? user.ProfilePictureUrl;
            user.Headline = request.User.Headline ?? user.Headline;
            user.Summary = request.User.Summary ?? user.Summary;
            user.CurrentCompany = request.User.CurrentCompany ?? user.CurrentCompany;
            user.CurrentPosition = request.User.CurrentPosition ?? user.CurrentPosition;
            user.Location = request.User.Location ?? user.Location;
            user.Industry = request.User.Industry ?? user.Industry;
            user.LinkedInUrl = request.User.LinkedInUrl ?? user.LinkedInUrl;

            user.UpdatedDate = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            return Result.Success();
        }
    }
}
