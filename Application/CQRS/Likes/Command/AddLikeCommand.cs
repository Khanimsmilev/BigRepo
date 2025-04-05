using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Likes.Command;

public class AddLikeCommand : IRequest<Result<string>>
{ 
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
}
