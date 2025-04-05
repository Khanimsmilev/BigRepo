using Application.CQRS.UserFollowRequests.DTOs;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.UserFollowRequests.Queries.Handlers;

public class GetPendingFollowRequestsQueryHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext
) : IRequestHandler<GetPendingFollowRequestsQuery, Result<List<PendingFollowRequestDto>>>
{
    public async Task<Result<List<PendingFollowRequestDto>>> Handle(GetPendingFollowRequestsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = userContext.MustGetUserId();

        var requests = await unitOfWork.UserFollowRequestRepository.GetPendingRequestsForUser(currentUserId);

        var result = requests.Select(r => new PendingFollowRequestDto
        {
            RequestId = r.Id,
            FromUserId = r.FromUserId,
            FromUserFullName = $"{r.FromUser?.FirstName} {r.FromUser?.LastName}",
            SentAt = r.CreatedDate
        }).ToList();

        return Result<List<PendingFollowRequestDto>>.Success(result);
    }
}
