using DAL.SqlServer.Context;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlUserFollowRequestRepository(AppDbContext context) : IUserFollowRequestRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(UserFollowRequest request)
    {
        await _context.UserFollowRequests.AddAsync(request);
    }

    public async Task<UserFollowRequest?> GetByIdAsync(int requestId)
    {
        return await _context.UserFollowRequests.FirstOrDefaultAsync(r=>r.Id == requestId);
    }

    public async Task<UserFollowRequest?> GetRequestAsync(int fromUserId, int toUserId)
    {
        return await _context.UserFollowRequests
            .FirstOrDefaultAsync(r => r.FromUserId == fromUserId && r.ToUserId == toUserId);
    }

    public async Task<List<UserFollowRequest>> GetPendingRequestsForUser(int toUserId)
    {
        return await _context.UserFollowRequests
            .Include(r => r.FromUser)
            .Where(r => r.ToUserId == toUserId && r.Status == FollowRequestStatus.Pending)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
