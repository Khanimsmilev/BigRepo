using MediatR;
using Common.GlobalResponses.Generics;
using Application.CQRS.Posts.DTOs;

namespace Application.CQRS.Posts.Commands;

public class AddPostCommand : IRequest<Result<PostDto>>
{
    public string Content { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
}