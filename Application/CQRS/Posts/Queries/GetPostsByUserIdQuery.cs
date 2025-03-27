using Application.CQRS.Posts.DTOs;
using MediatR;

namespace Application.CQRS.Posts.Queries;

public class GetPostsByUserIdQuery : IRequest<List<PostDto>>
{
    public int UserId { get; set; }
}
