using Domain.Abstraction;

namespace Domain.Entities;

public class Notification : BaseEntity
{

    public int UserId { get; set; } //bildiris gonderilen user
    public User User { get; set; }

    public string Message { get; set; }
    public bool IsRead { get; set; } // oxunanda true olur
}