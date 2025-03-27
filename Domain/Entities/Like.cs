using Domain.Abstraction;

namespace Domain.Entities;

public class Like : BaseEntity
{
    public int UserId { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public DateTime LikedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public Post? Post { get; set; }
    public Comment? Comment { get; set; }
}
