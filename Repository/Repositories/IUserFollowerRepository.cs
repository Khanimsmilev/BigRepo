using Domain.Entities;

namespace Repository.Repositories;

public interface IUserFollowerRepository
{
    Task AddAsync(UserFollower follower);
    Task<bool> IsFollowingAsync(int followerId, int followingId);
    Task<List<UserFollower>> GetFollowersAsync(int userId);
    Task<List<UserFollower>> GetFollowingAsync(int userId);
}
