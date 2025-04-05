namespace Application.CQRS.UserFollowRequests.DTOs;

public class PendingFollowRequestDto
{
    public int RequestId { get; set; }
    public int FromUserId { get; set; }
    public string FromUserFullName { get; set; }
    public DateTime SentAt { get; set; }
}
