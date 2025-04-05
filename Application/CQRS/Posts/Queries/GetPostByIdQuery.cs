using Application.CQRS.Posts.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Posts.Queries;

public class GetPostByIdQuery : IRequest<Result<PostDto>>
{
    public int PostId { get; set; }
}
