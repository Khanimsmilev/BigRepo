﻿namespace Application.CQRS.Posts.DTOs;

public class CreatePostDto
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
}
