using Application.CQRS.Posts.DTOs;
using MediatR;

namespace Application.CQRS.Posts.Queries;

public class GetAllPostsQuery : IRequest<List<PostDto>>
{
}
