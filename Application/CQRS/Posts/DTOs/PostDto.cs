namespace Application.CQRS.Posts.DTOs;

public class PostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}

