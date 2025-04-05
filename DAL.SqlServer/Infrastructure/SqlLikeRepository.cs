using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;


namespace DAL.SqlServer.Infrastructure;

public class SqlLikeRepository(AppDbContext context) : ILikeRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Like like)
    {
        await _context.Likes.AddAsync(like);
    }

    public async Task RemoveAsync(Like like)
    {
        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();
    }

    public async Task<Like?> GetByUserAndPostAsync(int userId, int postId)
    {
        return await _context.Likes
            .FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == postId);
    }

    public async Task<Like?> GetByUserAndCommentAsync(int userId, int commentId)
    {
        return await _context.Likes
            .FirstOrDefaultAsync(l => l.UserId == userId && l.CommentId == commentId);
    }

    public async Task<List<Like>> GetLikesByPostIdAsync(int postId)
    {
        return await _context.Likes
            .Include(l => l.User)
            .Where(l => l.PostId == postId && !l.IsDeleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}