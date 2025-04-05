namespace Application.CQRS.Users.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
   /* public string ProfilePictureUrl { get; set; }
    public string Headline { get; set; } // mes: "Software Engineer"
    public string Summary { get; set; } // qisa tesvir
    public string Bio { get; set; } // etrafli tesvir
    public string CurrentCompany { get; set; } 
    public string CurrentPosition { get; set; }
    public string Location { get; set; } 
    public string Industry { get; set; } //islediyi sahe mes: it, educatin, bank ...*/
}

