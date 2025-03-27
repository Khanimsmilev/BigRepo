using Application.CQRS.Messages.DTOs;
using MediatR;

namespace Application.CQRS.Messages.Commands;

public class CreateMessageCommand : IRequest<MessageResponseDto>
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Content { get; set; }
}
