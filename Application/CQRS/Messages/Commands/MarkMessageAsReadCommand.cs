using MediatR;

namespace Application.CQRS.Messages.Commands;

//sonra istifade edecem, real-time chat quranda

public class MarkMessageAsReadCommand : IRequest<bool>
{
    public int MessageId { get; set; }
}
