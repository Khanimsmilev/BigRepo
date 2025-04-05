using Application.CQRS.Comments.DTOs;
using Application.CQRS.Comments.Queries;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Comments.Handlers.QueryHandlers;

public class GetCommentsByPostIdQueryHandler(
    IUnitOfWork unitOfWork
) : IRequestHandler<GetCommentsByPostIdQuery, Result<List<CommentDto>>>
{
    public async Task<Result<List<CommentDto>>> Handle(GetCommentsByPostIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await unitOfWork.CommentRepository.GetByPostIdAsync(request.PostId);

        if (comments == null || comments.Count == 0)
            return Result<List<CommentDto>>.Failure("No comments found for this post.");

        var result = comments.Select(comment => new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedDate = comment.CreatedDate,
            UserId = comment.UserId,
            AuthorFullName = $"{comment.User.FirstName} {comment.User.LastName}"
        }).ToList();

        return Result<List<CommentDto>>.Success(result);
    }
}