using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.SqlServer.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserFollower> UserFollowers { get; set; }
    public DbSet<UserFollowRequest> UserFollowRequests { get; set; }
    public DbSet<Notification> Notifications { get; set; }

}