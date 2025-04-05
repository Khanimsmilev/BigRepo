using Application.CQRS.Comments.Commands;
using Application.CQRS.Comments.DTOs;
using Application.Security;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Comments.Handlers.CommandHandlers;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Result<CommentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public AddCommentCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Result<CommentDto>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment
        {
            PostId = request.PostId,
            UserId = _userContext.MustGetUserId(),
            Content = request.Content,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.CommentRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result<CommentDto>.Success(new CommentDto
        {
            Id = comment.Id,
            PostId = comment.PostId,
            UserId = comment.UserId,
            Content = comment.Content,
            CreatedDate = comment.CreatedDate
        });
    }
}
