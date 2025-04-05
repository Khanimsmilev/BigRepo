using Application.CQRS.UserFollowRequests.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.UserFollowRequests.Queries;
public class GetPendingFollowRequestsQuery : IRequest<Result<List<PendingFollowRequestDto>>> { }
