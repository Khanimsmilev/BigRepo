namespace Application.CQRS.Posts.DTOs;

public class CreatePostResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } 
}
