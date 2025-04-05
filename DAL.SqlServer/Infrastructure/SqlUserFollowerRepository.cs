using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlUserFollowerRepository(AppDbContext context) : IUserFollowerRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(UserFollower follower)
    {
        await _context.UserFollowers.AddAsync(follower);
    }

    public async Task<bool> IsFollowingAsync(int followerId, int followingId)
    {
        return await _context.UserFollowers
            .AnyAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);
    }

    public async Task<List<UserFollower>> GetFollowersAsync(int userId)
    {
        return await _context.UserFollowers
            .Where(f => f.FollowingId == userId)
            .ToListAsync();
    }

    public async Task<List<UserFollower>> GetFollowingAsync(int userId)
    {
        return await _context.UserFollowers
            .Where(f => f.FollowerId == userId)
            .ToListAsync();
    }
}
