namespace Application.CQRS.Messages.DTOs;

public class MessageResponseDto
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; }
}
