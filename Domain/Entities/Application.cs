using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities;

public class Application : BaseEntity
{
    public int UserId { get; set; }
    public int JobPostId { get; set; }
    public RequestStatus Status { get; set; } = RequestStatus.Pending; // Pending, Accepted, Rejected
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public JobPost JobPost { get; set; }
}

