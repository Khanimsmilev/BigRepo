using Domain.Entities;

namespace Repository.Repositories;

public interface IUserFollowRequestRepository
{
    Task<UserFollowRequest?> GetRequestAsync(int fromUserId, int toUserId);
    Task AddAsync(UserFollowRequest request);
    Task<List<UserFollowRequest>> GetPendingRequestsForUser(int toUserId);
    Task<UserFollowRequest?> GetByIdAsync(int requestId);
    Task SaveChangesAsync();
}
