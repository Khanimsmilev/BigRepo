using Application.CQRS.Posts.DTOs;
using MediatR;

namespace Application.CQRS.Posts.Queries;

public class GetPostByIdQuery(int id) : IRequest<PostDto>
{
    public int Id { get; set; } = id;
}
