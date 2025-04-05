using Application.CQRS.Likes.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Likes.Queries;

public class GetLikesByPostIdQuery : IRequest<Result<List<LikeDto>>>
{
    public int PostId { get; set; }
}