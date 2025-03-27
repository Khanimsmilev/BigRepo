using Domain.Abstraction;

namespace Domain.Entities;

public class Connection : BaseEntity
{

    public int UserId { get; set; }
    public User User { get; set; }

    public int ConnectedUserId { get; set; }
    public User ConnectedUser { get; set; } //qarsii teref 
}
