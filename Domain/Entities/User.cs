using Domain.Abstraction;
using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Domain.Entities;


public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } 
    public string PasswordSalt { get; set; } 
    public string ProfilePictureUrl { get; set; }
    public string CoverPhotoUrl { get; set; }
    public string Headline { get; set; } // profil basligi (mes: Software Engineer at Google)
    public string Summary { get; set; } // qısa bio
    public string Bio { get; set; } // etraflı bio

    public string CurrentCompany { get; set; }
    public string CurrentPosition { get; set; }
    public string Location { get; set; }
    public string Industry { get; set; }
    [NotMapped]
    public List<string>? Skills { get; set; }
    public string LinkedInUrl { get; set; }
    [NotMapped]
    public ICollection<UserRelationship> SentRequests { get; set; } //follow connection gonderen
    public ICollection<UserRelationship> ReceivedRequests { get; set; } //qebul eden

    [NotMapped]
    public ICollection<Message> SentMessages { get; set; } // gonderilen
    [NotMapped]
    public ICollection<Message> ReceivedMessages { get; set; } // qebul edilen
    [NotMapped]
    public ICollection<Notification> Notifications { get; set; }
    [NotMapped]
    public ICollection<WorkExperience> WorkExperiences { get; set; }
    [NotMapped]
    public ICollection<Education> EducationHistory { get; set; }
    [NotMapped]
    public ICollection<Post> Posts { get; set; }
    [NotMapped]
    public ICollection<Comment> Comments { get; set; }


    public DateTime? LastActiveAt { get; set; }

    public UserRoles Role { get; set; } = UserRoles.User;

    

}