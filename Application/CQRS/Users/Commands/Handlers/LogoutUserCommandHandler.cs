using Application.CQRS.Users.Commands;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Users.Commands.Handlers;
public class LogoutUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<LogoutUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var token = await unitOfWork.RefreshTokenRepository.GetStoredRefreshToken(request.RefreshToken);
        if (token is null)
            return Result<string>.Failure("Token not found");

        token.IsRevoked = true;
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("Logged out successfully.");
    }
}