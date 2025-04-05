using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Posts.Commands;

public class DeletePostCommand : IRequest<Result<string>>
{
    public int PostId { get; set; }
}
