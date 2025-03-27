using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlPostRepository(AppDbContext context) : IPostRepository
{
    private readonly AppDbContext _context = context;


    public async Task<Post> GetByIdAsync(int id)
    {
        return (await _context.Posts.FirstOrDefaultAsync(p => p.Id == id))!;
    }

    public IQueryable<Post> GetAll()
    {
        return _context.Posts.Where(p => !p.IsDeleted);
    }

    public IQueryable<Post> GetByUserId(int userId)
    {
        return _context.Posts.Where(p => p.UserId == userId && !p.IsDeleted);
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Post post)
    {
        post.UpdatedDate = DateTime.UtcNow;
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            post.IsDeleted = true;
            post.DeletedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}

