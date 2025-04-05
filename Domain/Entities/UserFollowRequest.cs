using Domain.Abstraction;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class UserFollowRequest : BaseEntity
{
    public int Id { get; set; }

    public int FromUserId { get; set; }
    //[ForeignKey("FromUserId")]
    public User FromUser { get; set; }
    public int ToUserId { get; set; }
    //[ForeignKey("ToUserId")]
    public User ToUser { get; set; }

    public FollowRequestStatus Status { get; set; } = FollowRequestStatus.Pending;
    public DateTime? RespondedDate { get; set; } = null;
}
