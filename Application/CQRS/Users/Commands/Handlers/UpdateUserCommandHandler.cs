using Application.CQRS.Users.Commands;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Users.Commands.Handlers;
public class UpdateUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext
) : IRequestHandler<UpdateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.MustGetUserId();

        var user = await unitOfWork.UserRepository.GetByIdAsync(userId);
        if (user == null) return Result<string>.Failure("User not found");

        var dto = request.Dto;
        user.FirstName = dto.FirstName ?? user.FirstName;
        user.LastName = dto.LastName ?? user.LastName;
        user.ProfilePictureUrl = dto.ProfilePictureUrl ?? user.ProfilePictureUrl;
        user.CoverPhotoUrl = dto.CoverPhotoUrl ?? user.CoverPhotoUrl;
        user.Headline = dto.Headline ?? user.Headline;
        user.Summary = dto.Summary ?? user.Summary;
        user.Bio = dto.Bio ?? user.Bio;
        user.CurrentCompany = dto.CurrentCompany ?? user.CurrentCompany;
        user.CurrentPosition = dto.CurrentPosition ?? user.CurrentPosition;
        user.Location = dto.Location ?? user.Location;
        user.Industry = dto.Industry ?? user.Industry;

        user.UpdatedDate = DateTime.UtcNow;
        user.UpdatedBy = userId;

        await unitOfWork.UserRepository.UpdateAsync(user);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("User profile updated successfully.");
    }
}