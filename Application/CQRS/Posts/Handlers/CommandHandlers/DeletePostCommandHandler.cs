using Application.CQRS.Posts.Commands;
using Application.Security;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Posts.Handlers.CommandHandlers;

public class DeletePostCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext) : IRequestHandler<DeletePostCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await unitOfWork.PostRepository.GetByIdAsync(request.PostId);
        if (post == null || post.UserId != userContext.UserId)
            return Result<string>.Failure("Post not found or unauthorized");

        await unitOfWork.PostRepository.DeleteAsync(post);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("Post deleted successfully");
    }
}
