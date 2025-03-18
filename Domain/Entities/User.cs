using Domain.Abstraction;

namespace Domain.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string Bio { get; set; }
    public string Location { get; set; }
    public string Industry { get; set; }
    public string CurrentJobTitle { get; set; }
    public string Skills { get; set; } // AI üçün lazımlıdır
    //public DateTime CreatedAt { get; set; }

    // Bir istifadəçinin çoxlu iş elanları, əlaqələri və mesajları ola bilər
    public ICollection<JobPost> JobPosts { get; set; }
    public ICollection<Connection> Connections { get; set; }
    public ICollection<Message> Messages { get; set; }
}
