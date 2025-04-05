using Application.CQRS.Posts.DTOs;
using Application.CQRS.Posts.Queries;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Posts.Handlers.QueryHandlers;

public class GetPostByIdQueryHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    : IRequestHandler<GetPostByIdQuery, Result<PostDto>>
{
    public async Task<Result<PostDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = userContext.MustGetUserId();
        var post = await unitOfWork.PostRepository.GetByIdAsync(request.PostId);
        if (post == null)
            return Result<PostDto>.Failure("Post not found");

        var dto = new PostDto
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
        };

        return Result<PostDto>.Success(dto);
    }
}
