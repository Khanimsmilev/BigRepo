using Application.CQRS.Messages.Commands;
using Application.CQRS.Messages.DTOs;
using Application.CQRS.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkedIn_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Create a new message
    [HttpPost]
    public async Task<ActionResult<MessageResponseDto>> CreateMessage([FromBody] CreateMessageCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetMessagesByUser), new { userId = result.ReceiverId }, result);
    }

    // Get conversation between two users
    [HttpGet("conversation/{user1Id}/{user2Id}")]
    public async Task<ActionResult<List<MessageResponseDto>>> GetConversation(int user1Id, int user2Id)
    {
        var query = new GetConversationQuery(user1Id, user2Id);
        var result = await _mediator.Send(query);

        if (result == null || result.Count == 0)
            return NotFound("No messages found.");

        return Ok(result);
    }

    // Get messages for a user
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<MessageResponseDto>>> GetMessagesByUser(int userId)
    {
        var query = new GetMessagesByUserQuery(userId);
        var result = await _mediator.Send(query);

        if (result == null || result.Count == 0)
            return NotFound("No messages found.");

        return Ok(result);
    }

    // Get last message between two users
    [HttpGet("last/{user1Id}/{user2Id}")]
    public async Task<ActionResult<MessageResponseDto>> GetLastMessage(int user1Id, int user2Id)
    {
        var query = new GetLastMessageQuery(user1Id, user2Id);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound("No messages found.");

        return Ok(result);
    }

    // Get paginated messages for a user
    [HttpGet("paginated/{user1Id}/{user2Id}")]
    public async Task<ActionResult<List<MessageResponseDto>>> GetPaginatedMessages(int user1Id, int user2Id, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetPaginatedMessagesQuery
        {
            User1Id = user1Id,
            User2Id = user2Id,
            Page = page,
            PageSize = pageSize
        };

        var result = await _mediator.Send(query);

        if (result == null || result.Count == 0)
            return NotFound("No messages found.");

        return Ok(result);
    }
}
