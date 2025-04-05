namespace Application.CQRS.Posts.DTOs;

public class PostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public string AuthorFullName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public int CommentCount { get; set; }
    public int LikeCount { get; set; }
    public bool IsLikedByCurrentUser { get; set; }
}