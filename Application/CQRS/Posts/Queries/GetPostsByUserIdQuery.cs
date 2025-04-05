using Application.CQRS.Posts.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Posts.Queries;

public class GetPostsByUserIdQuery : IRequest<Result<List<PostDto>>>
{
    public int UserId { get; set; }
}
