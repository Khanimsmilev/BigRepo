using Application.CQRS.Likes.Commands;
using Application.Security;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

public class RemoveLikeCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    : IRequestHandler<RemoveLikeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RemoveLikeCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.MustGetUserId();


        if (request.PostId is null && request.CommentId is null)
        {
            return Result<string>.Failure("Either PostId or CommentId must be provided to remove a like.");
        }

        Like? like = null;

        if (request.PostId is not null)
        {
            like = await unitOfWork.LikeRepository.GetByUserAndPostAsync(userId, request.PostId.Value);
        }
        else if (request.CommentId is not null)
        {
            like = await unitOfWork.LikeRepository.GetByUserAndCommentAsync(userId, request.CommentId.Value);
        }

        if (like is null)
            return Result<string>.Failure("Like not found.");

        await unitOfWork.LikeRepository.RemoveAsync(like);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("Like removed successfully.");
    }
}