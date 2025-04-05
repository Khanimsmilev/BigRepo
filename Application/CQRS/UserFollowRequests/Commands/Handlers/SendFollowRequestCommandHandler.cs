using Application.Security;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Repository.Common;

namespace Application.CQRS.UserFollowRequests.Commands.Handlers;
public class SendFollowRequestCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext
) : IRequestHandler<SendFollowRequestCommand, Result<string>>
{
    public async Task<Result<string>> Handle(SendFollowRequestCommand request, CancellationToken cancellationToken)
    {
        var fromUserId = userContext.MustGetUserId();
        var toUserId = request.ToUserId;

        if (fromUserId == toUserId)
            return Result<string>.Failure("You cannot follow yourself.");

        var existingRequest = await unitOfWork.UserFollowRequestRepository.GetRequestAsync(fromUserId, toUserId);
        if (existingRequest != null)
            return Result<string>.Failure("Follow request already exists.");

        var newRequest = new UserFollowRequest
        {
            FromUserId = fromUserId,
            ToUserId = toUserId,
            Status = FollowRequestStatus.Pending
        };

        await unitOfWork.UserFollowRequestRepository.AddAsync(newRequest);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("Follow request sent.");
    }
}
