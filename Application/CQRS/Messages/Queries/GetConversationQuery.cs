using Application.CQRS.Messages.DTOs;
using MediatR;

namespace Application.CQRS.Messages.Queries;

public class GetConversationQuery : IRequest<List<MessageResponseDto>>
{
    public int User1Id { get; set; }
    public int User2Id { get; set; }

    public GetConversationQuery(int user1Id, int user2Id)
    {
        User1Id = user1Id;
        User2Id = user2Id;
    }
}
