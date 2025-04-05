using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlCommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public SqlCommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments
            .Include(c => c.User)
            .Include(c => c.Likes)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Comment>> GetByPostIdAsync(int postId)
    {
        return await _context.Comments
            .Include(c => c.User)
            .Include(c => c.Likes)
            .Where(c => c.PostId == postId)
            .ToListAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        comment.IsDeleted = true;
        comment.DeletedDate = DateTime.UtcNow;
    }
}