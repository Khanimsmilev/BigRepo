using Application.CQRS.RefreshToken.Commands;
using Application.CQRS.RefreshToken.DTOs;
using Application.CQRS.Users.Commands;
using Application.CQRS.Users.DTOs;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LinkedIn_Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess) return Ok(result.Message);
        return BadRequest(result.Message);
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess) return Ok(result.Message);
        return BadRequest(result.Message);
    }

    [HttpPost("complete-profile")]
    public async Task<IActionResult> CompleteProfile(CompleteProfileCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess) return Ok(result.Message);
        return BadRequest(result.Message);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutUserCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

}