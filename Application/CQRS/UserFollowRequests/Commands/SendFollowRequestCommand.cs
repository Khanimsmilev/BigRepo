using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.UserFollowRequests.Commands;
public class SendFollowRequestCommand(int toUserId) : IRequest<Result<string>>
{
    public int ToUserId { get; set; } = toUserId;
}
