using MediatR;
using Repository.Common;
using Application.Security;
using Common.GlobalResponses.Generics;
using Application.CQRS.Posts.DTOs;
using Domain.Entities;

namespace Application.CQRS.Posts.Commands.Handlers;

public class AddPostCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext) : IRequestHandler<AddPostCommand, Result<PostDto>>
{
    public async Task<Result<PostDto>> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            UserId = userContext.MustGetUserId(),
            Content = request.Content,
            ImageUrl = request.ImageUrl,
            VideoUrl = request.VideoUrl,
            CreatedDate = DateTime.UtcNow
        };

        await unitOfWork.PostRepository.AddAsync(post);
        await unitOfWork.SaveChangesAsync();

        var dto = new PostDto
        {
            Id = post.Id,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            VideoUrl = post.VideoUrl,
            CreatedDate = post.CreatedDate,
            AuthorFullName = "", 
            CommentCount = 0,
            LikeCount = 0
        };

        return Result<PostDto>.Success(dto);
    }
}