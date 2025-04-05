using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Likes.Commands;

public class RemoveLikeCommand : IRequest<Result<string>>
{
    public int? PostId { get; set; }

    public int? CommentId { get; set; }
}