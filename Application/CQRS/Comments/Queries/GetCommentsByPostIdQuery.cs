using Application.CQRS.Comments.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Comments.Queries;

public class GetCommentsByPostIdQuery : IRequest<Result<List<CommentDto>>>
{
    public int PostId { get; set; }
}

