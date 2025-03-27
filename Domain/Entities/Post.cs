using Domain.Abstraction;

namespace Domain.Entities;

public class Post : BaseEntity
{

    public int UserId { get; set; }
    public User User { get; set; }

    public string Content { get; set; }

    public string ImageUrl { get; set; } 

    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }

}

