using Application.CQRS.Likes.DTOs;
using Application.CQRS.Likes.Queries;
using Common.GlobalResponses.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository.Common;

namespace Application.CQRS.Likes.Handlers.Queries;

public class GetLikesByPostIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetLikesByPostIdQuery, Result<List<LikeDto>>>
{
    public async Task<Result<List<LikeDto>>> Handle(GetLikesByPostIdQuery request, CancellationToken cancellationToken)
    {
        var likes = await unitOfWork.LikeRepository
            .GetLikesByPostIdAsync(request.PostId);

        var result = likes.Select(x => new LikeDto
        {
            UserId = x.UserId,
            PostId = x.PostId,
            UserFullName = x.User !=null ? $"{x.User.FirstName} {x.User.LastName}" : "Unknown User",
        }).ToList();

        return Result<List<LikeDto>>.Success(result);
    }
}