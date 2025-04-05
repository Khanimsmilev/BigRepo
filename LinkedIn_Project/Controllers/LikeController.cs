using Application.CQRS.Likes.Command;
using Application.CQRS.Likes.Commands;
using Application.CQRS.Likes.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn_Project.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LikeController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator;
    [HttpPost]
    public async Task<IActionResult> AddLike(AddLikeCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveLikeCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("by-post/{postId}")]
    public async Task<IActionResult> GetByPostId(int postId)
    {
        var result = await _mediator.Send(new GetLikesByPostIdQuery { PostId = postId });
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}