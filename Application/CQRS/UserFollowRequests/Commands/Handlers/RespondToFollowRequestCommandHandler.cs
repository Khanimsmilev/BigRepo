using Application.Security;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Repository.Common;

namespace Application.CQRS.UserFollowRequests.Commands.Handlers;
public class RespondToFollowRequestCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext
) : IRequestHandler<RespondToFollowRequestCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RespondToFollowRequestCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = userContext.MustGetUserId();

        var followRequest = await unitOfWork.UserFollowRequestRepository.GetByIdAsync(request.RequestId);
        if (followRequest == null || followRequest.ToUserId != currentUserId)
            return Result<string>.Failure("Follow request not found or not authorized.");

        if (followRequest.Status != FollowRequestStatus.Pending)
            return Result<string>.Failure("Follow request already responded.");

        followRequest.Status = request.Accept ? FollowRequestStatus.Accepted : FollowRequestStatus.Rejected;
        followRequest.RespondedDate = DateTime.UtcNow;

        if (request.Accept)
        {
            var follower = new UserFollower
            {
                FollowerId = followRequest.FromUserId,
                FollowingId = followRequest.ToUserId
            };

            await unitOfWork.UserFollowerRepository.AddAsync(follower);
        }

        await unitOfWork.SaveChangesAsync();
        return Result<string>.Success(request.Accept ? "Follow request accepted." : "Follow request rejected.");
    }
}
