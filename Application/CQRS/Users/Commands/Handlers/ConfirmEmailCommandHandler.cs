using Common.GlobalResponses;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Users.Commands.Handlers;
public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmEmailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);
        if (user == null || user.EmailConfirmationCode != request.Code)
            return Result.Failure("Invalid email or code.");

        user.IsEmailConfirmed = true;
        user.EmailConfirmationCode = null;
        await _unitOfWork.UserRepository.UpdateAsync(user);

        return Result.Success("Email confirmed successfully.");
    }
}