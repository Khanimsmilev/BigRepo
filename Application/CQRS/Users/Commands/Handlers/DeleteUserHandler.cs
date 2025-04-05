using Application.CQRS.Users.Commands;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;


namespace Application.CQRS.Users.Commands.Handlers;
public class DeleteUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext
) : IRequestHandler<DeleteUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.MustGetUserId();

        var user = await unitOfWork.UserRepository.GetByIdAsync(userId);
        if (user == null) return Result<string>.Failure("User not found");

        user.IsDeleted = true;
        user.DeletedDate = DateTime.UtcNow;
        user.DeletedBy = userId;

        await unitOfWork.UserRepository.UpdateAsync(user);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("User deleted successfully.");
    }
}