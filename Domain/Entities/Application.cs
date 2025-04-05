using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities;

public class Application : BaseEntity // application is a request to follow a job post
{
    public int UserId { get; set; }
    public int JobPostId { get; set; }
    public FollowRequestStatus Status { get; set; } = FollowRequestStatus.Pending; // Pending, Accepted, Rejected
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public JobPost JobPost { get; set; }
}

