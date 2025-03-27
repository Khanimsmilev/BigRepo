using Application.CQRS.Messages.DTOs;
using Application.CQRS.Messages.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace Application.CQRS.Messages.Handlers.QueryHandlers;


public class GetMessagesByUserQueryHandler : IRequestHandler<GetMessagesByUserQuery, List<MessageResponseDto>>
{
    private readonly IMessageRepository _messageRepository;

    public GetMessagesByUserQueryHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<List<MessageResponseDto>> Handle(GetMessagesByUserQuery request, CancellationToken cancellationToken)
    {
        var messages = await _messageRepository.GetByUserId(request.UserId)
            .OrderBy(m => m.CreatedDate)
            .Select(m => new MessageResponseDto
            {
                Id = m.Id,
                SenderId = m.SenderId,
                ReceiverId = m.ReceiverId,
                Content = m.Content,
                IsRead = m.IsRead,
                CreatedDate = m.CreatedDate
            })
            .ToListAsync(cancellationToken);

        return messages;
    }
}
