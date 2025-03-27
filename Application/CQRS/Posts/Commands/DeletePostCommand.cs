using MediatR;

namespace Application.CQRS.Posts.Commands;

public class DeletePostCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
