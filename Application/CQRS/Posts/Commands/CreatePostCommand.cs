using Application.CQRS.Posts.DTOs;
using MediatR;

namespace Application.CQRS.Posts.Commands;
public class CreatePostCommand : IRequest<CreatePostResponseDto>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
}
