using MediatR;

namespace Application.CQRS.Posts.Commands;

public class UpdatePostCommand : IRequest
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
}
