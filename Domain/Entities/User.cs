using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }

    public string? ProfilePictureUrl { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? Headline { get; set; }
    public string? Summary { get; set; }
    public string? Bio { get; set; }

    public string? CurrentCompany { get; set; }
    public string? CurrentPosition { get; set; }
    public string? Location { get; set; }
    public string? Industry { get; set; }

    public string? LinkedInUrl { get; set; }

    public bool IsEmailConfirmed { get; set; }
    public string? EmailConfirmationCode { get; set; }

    public DateTime? LastActiveAt { get; set; }

    public UserRoles Role { get; set; } = UserRoles.User;


/*    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Skill> Skills { get; set; }*/

}