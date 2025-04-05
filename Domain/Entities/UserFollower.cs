using Domain.Abstraction;

namespace Domain.Entities;

public class UserFollower : BaseEntity
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }

}
