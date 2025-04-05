using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.UserFollowRequests.Commands;
public class RespondToFollowRequestCommand : IRequest<Result<string>>
{
    public int RequestId { get; set; }
    public bool Accept { get; set; } // true - accept, false - reject
}
