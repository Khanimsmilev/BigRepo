using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

public class SqlPostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public SqlPostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }

    public async Task<List<Post>> GetByUserIdAsync(int userId)
    {
        return await _context.Posts
            .Where(p => p.UserId == userId && !p.IsDeleted)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .ToListAsync();
    }

    public async Task<List<Post>> GetAllAsync()
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .Where(p => !p.IsDeleted)
            .ToListAsync();
    }

    public async Task UpdateAsync(Post post)
    {
        _context.Posts.Update(post);
    }

    public async Task DeleteAsync(Post post)
    {
        post.IsDeleted = true;
        post.DeletedDate = DateTime.UtcNow;
        _context.Posts.Update(post);
    }
}