namespace Application.CQRS.Users.DTOs;

public class UpdateUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? Headline { get; set; }
    public string? Summary { get; set; }
    public string? Bio { get; set; }
    public string? CurrentCompany { get; set; }
    public string? CurrentPosition { get; set; }
    public string? Location { get; set; }
    public string? Industry { get; set; }
}

