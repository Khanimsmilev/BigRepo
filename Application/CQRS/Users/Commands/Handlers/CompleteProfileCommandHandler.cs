using Common.GlobalResponses;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Users.Commands.Handlers;
public class CompleteProfileCommandHandler : IRequestHandler<CompleteProfileCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompleteProfileCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CompleteProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);
        if (user == null || !user.IsEmailConfirmed)
            return Result.Failure("Email is not confirmed.");

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Location = request.Location;
        user.CurrentPosition = request.CurrentJobTitle;
        user.CurrentCompany = request.CurrentCompany;

        await _unitOfWork.UserRepository.UpdateAsync(user);

        return Result.Success("Profile completed successfully.");
    }
}