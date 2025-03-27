using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Users.Commands.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null || user.IsDeleted)
                return Result<int>.Failure(new List<string> { "User not found or already deleted" });


            user.IsDeleted = true;
            user.DeletedDate = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            return Result.Success();
        }
    }
}

