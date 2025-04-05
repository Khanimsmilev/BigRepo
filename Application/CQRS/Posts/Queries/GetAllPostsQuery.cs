using MediatR;
using Common.GlobalResponses.Generics;
using Application.CQRS.Posts.DTOs;

namespace Application.CQRS.Posts.Queries;

public class GetAllPostsQuery : IRequest<Result<List<PostDto>>>
{
}