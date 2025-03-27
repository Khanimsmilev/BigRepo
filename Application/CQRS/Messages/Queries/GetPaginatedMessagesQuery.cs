using Application.CQRS.Messages.DTOs;
using MediatR;

namespace Application.CQRS.Messages.Queries;

public class GetPaginatedMessagesQuery : IRequest<List<MessageResponseDto>>
{
    public int User1Id { get; set; }
    public int User2Id { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
