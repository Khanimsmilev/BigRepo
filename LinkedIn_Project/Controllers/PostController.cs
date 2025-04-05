using Application.CQRS.Posts.Commands;
using Application.CQRS.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(AddPostCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPostsQuery());
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdatePostCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeletePostCommand { PostId = id });
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetPostByIdQuery { PostId = id });
        if (!result.IsSuccess)
            return NotFound(result); // BadRequest yazanda onu elave ederem

        return Ok(result);
    }

    [HttpGet("by-user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var result = await _mediator.Send(new GetPostsByUserIdQuery { UserId = userId });
        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}
