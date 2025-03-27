using Application.CQRS.Messages.Commands;
using Application.CQRS.Messages.DTOs;
using Domain.Entities;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Messages.Handlers.CommandHandlers;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageResponseDto>
{
    private readonly IMessageRepository _messageRepository;

    public CreateMessageCommandHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<MessageResponseDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId,
            Content = request.Content,
            CreatedDate = DateTime.UtcNow,
            IsRead = false
        };

        var addedMessage = await _messageRepository.AddAsync(message);

        return new MessageResponseDto
        {
            Id = addedMessage.Id,
            SenderId = addedMessage.SenderId,
            ReceiverId = addedMessage.ReceiverId,
            Content = addedMessage.Content,
            IsRead = addedMessage.IsRead,
            CreatedDate = addedMessage.CreatedDate
        };
    }
}
