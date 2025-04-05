using Application.CQRS.Likes.Command;
using Application.Security;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Likes.Handlers;

public class AddLikeCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    : IRequestHandler<AddLikeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(AddLikeCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.MustGetUserId();

        if (request.PostId is null)
            return Result<string>.Failure("PostId is required.");

        var existingLike = await unitOfWork.LikeRepository
            .GetByUserAndPostAsync(request.PostId.Value, userId);

        if (existingLike is not null)
            return Result<string>.Failure("You have already liked this post.");

        var like = new Like
        {
            UserId = userId,
            PostId = request.PostId.Value,
            //CommentId = request.CommentId.Value,
            CreatedBy = userId
        };

        await unitOfWork.LikeRepository.AddAsync(like);
        await unitOfWork.SaveChangesAsync();

        return Result<string>.Success("Like added successfully.");
    }
}