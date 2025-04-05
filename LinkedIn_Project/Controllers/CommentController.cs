using Application.CQRS.Comments.Commands;
using Application.CQRS.Comments.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddCommentCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("by-post/{postId}")]
    public async Task<IActionResult> GetByPostId(int postId)
    {
        var result = await _mediator.Send(new GetCommentsByPostIdQuery { PostId = postId });
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
