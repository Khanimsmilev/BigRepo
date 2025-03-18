using Domain.Abstraction;

namespace Domain.Entities;

public class Post : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public string Content { get; set; }
    public string ImageUrl { get; set; } // Əgər post şəkil daxildir
    //public DateTime CreatedAt { get; set; }
}
