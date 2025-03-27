using Application.CQRS.Messages.DTOs;
using Application.CQRS.Messages.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace Application.CQRS.Messages.Handlers.QueryHandlers;

public class GetLastMessageQueryHandler : IRequestHandler<GetLastMessageQuery, MessageResponseDto>
{
    private readonly IMessageRepository _messageRepository;

    public GetLastMessageQueryHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<MessageResponseDto> Handle(GetLastMessageQuery request, CancellationToken cancellationToken)
    {
        var lastMessage = await _messageRepository.GetConversation(request.User1Id, request.User2Id)
            .OrderByDescending(m => m.CreatedDate)
            .FirstOrDefaultAsync(cancellationToken);

        if (lastMessage == null)
            return null;

        return new MessageResponseDto
        {
            Id = lastMessage.Id,
            SenderId = lastMessage.SenderId,
            ReceiverId = lastMessage.ReceiverId,
            Content = lastMessage.Content,
            IsRead = lastMessage.IsRead,
            CreatedDate = lastMessage.CreatedDate
        };
    }
}
