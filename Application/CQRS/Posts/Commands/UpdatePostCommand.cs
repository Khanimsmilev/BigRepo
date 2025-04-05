using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Posts.Commands;

public class UpdatePostCommand : IRequest<Result<string>>
{
    public int PostId { get; set; }
    public string Content { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
}
