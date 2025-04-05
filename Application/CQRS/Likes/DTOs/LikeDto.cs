namespace Application.CQRS.Likes.DTOs;

public class LikeDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string UserFullName { get; set; } = string.Empty;
}