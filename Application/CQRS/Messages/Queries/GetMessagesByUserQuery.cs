using Application.CQRS.Messages.DTOs;
using MediatR;

namespace Application.CQRS.Messages.Queries;

public class GetMessagesByUserQuery : IRequest<List<MessageResponseDto>>
{
    public int UserId { get; set; }

    public GetMessagesByUserQuery(int userId)
    {
        UserId = userId;
    }
}
