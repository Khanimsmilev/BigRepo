using MediatR;
using Repository.Common;
using Common.GlobalResponses.Generics;
using Application.CQRS.Posts.DTOs;
using Microsoft.EntityFrameworkCore;
using Application.Security;

namespace Application.CQRS.Posts.Queries.Handlers;

public class GetAllPostsQueryHandler(IUnitOfWork unitOfWork, IUserContext userContext) : IRequestHandler<GetAllPostsQuery, Result<List<PostDto>>>
{
    public async Task<Result<List<PostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = userContext.MustGetUserId();
        var posts = await unitOfWork.PostRepository.GetAllAsync();

        var result = posts.Select(p => new PostDto
        {
            Id = p.Id,
            UserId = p.UserId,
            Content = p.Content,
            ImageUrl = p.ImageUrl,
            VideoUrl = p.VideoUrl,
            CreatedDate = p.CreatedDate,
            AuthorFullName = $"{p.User.FirstName} {p.User.LastName}",
            CommentCount = p.Comments?.Count ?? 0,
            LikeCount = p.Likes?.Count ?? 0,
            IsLikedByCurrentUser = p.Likes.Any(likes => likes.UserId == currentUserId && !likes.IsDeleted)
        }).ToList();

        return Result<List<PostDto>>.Success(result);
    }
}