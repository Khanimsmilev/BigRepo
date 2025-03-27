using Application.CQRS.Posts.Commands;
using Application.CQRS.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var result = await _mediator.Send(new GetAllPostsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var result = await _mediator.Send(new GetPostByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPostById), new { id=  result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID uyğunsuzluğu!");

        await _mediator.Send(command);
        return Ok();
    }


    [HttpDelete("{id}")] 
    public async Task<IActionResult> DeletePost(int id)
    {
        await _mediator.Send(new DeletePostCommand(id));
        return NoContent();
    }
}
