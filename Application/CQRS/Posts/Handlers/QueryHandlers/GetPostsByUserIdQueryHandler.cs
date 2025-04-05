using Application.CQRS.Posts.DTOs;
using Application.CQRS.Posts.Queries;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Posts.Handlers.QueryHandlers;

public class GetPostsByUserIdQueryHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    : IRequestHandler<GetPostsByUserIdQuery, Result<List<PostDto>>>
{
    public async Task<Result<List<PostDto>>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = userContext.MustGetUserId();
        var posts = await unitOfWork.PostRepository.GetByUserIdAsync(request.UserId);

        var dtos = posts.Select(post => new PostDto
        {
            Id = post.Id,
            UserId = post.UserId,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            VideoUrl = post.VideoUrl,
            CommentCount = post.Comments.Count,
            LikeCount = post.Likes.Count,
            AuthorFullName = post.User.FirstName + " " + post.User.LastName,
            CreatedDate = post.CreatedDate,
            IsLikedByCurrentUser = post.Likes.Any(like => like.UserId == currentUserId && !like.IsDeleted)
        }).ToList();

        return Result<List<PostDto>>.Success(dtos);
    }
}
