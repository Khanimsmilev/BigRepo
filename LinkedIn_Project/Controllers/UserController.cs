using Application.CQRS.UserFollowRequests.Commands;
using Application.CQRS.Users.Commands;
using Application.CQRS.Users.DTOs;
using Application.CQRS.Users.Queries;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn_Project.Controllers;

[Route("api/users")]
[ApiController]
// [Authorize] 
public class UserController(IMediator mediator) : ControllerBase
{

    private readonly IMediator _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDto dto)
    {
        var result = await _mediator.Send(new UpdateUserCommand(dto));
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser()
    {
        var result = await _mediator.Send(new DeleteUserCommand());
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("follow")]
    public async Task<IActionResult> SendFollowRequest([FromQuery] int toUserId)
    {
        var result = await mediator.Send(new SendFollowRequestCommand(toUserId));
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("follow/respond")]
    public async Task<IActionResult> RespondToFollowRequest([FromBody] RespondToFollowRequestCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }


}