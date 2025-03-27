using Application.CQRS.Messages.Commands;
using MediatR;
using Repository.Repositories;

namespace Application.CQRS.Messages.Handlers.CommandHandlers;

public class MarkMessageAsReadCommandHandler : IRequestHandler<MarkMessageAsReadCommand, bool>
{
    private readonly IMessageRepository _messageRepository;

    public MarkMessageAsReadCommandHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<bool> Handle(MarkMessageAsReadCommand request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetByIdAsync(request.MessageId);
        if (message == null || message.IsRead)
            return false;

        message.IsRead = true;
        await _messageRepository.UpdateAsync(message);
        return true;
    }
}
