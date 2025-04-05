using Application.CQRS.Posts.Commands;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Posts.Handlers.CommandHandlers;

public class UpdatePostCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext) : IRequestHandler<UpdatePostCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await unitOfWork.PostRepository.GetByIdAsync(request.PostId);
        if (post == null || post.UserId != userContext.UserId)
            return Result<string>.Failure("Post not found or unauthorized");

        post.Content = request.Content;
        post.ImageUrl = request.ImageUrl;
        post.VideoUrl = request.VideoUrl;
        post.UpdatedDate = DateTime.UtcNow;
        post.UpdatedBy = userContext.UserId;

        await unitOfWork.PostRepository.UpdateAsync(post);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("Post updated successfully");
    }
}
