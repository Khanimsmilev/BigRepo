﻿using Domain.Abstraction;

namespace Domain.Entities;

public class Comment : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public string Content { get; set; }

    public ICollection<Like> Likes { get; set; }

}
