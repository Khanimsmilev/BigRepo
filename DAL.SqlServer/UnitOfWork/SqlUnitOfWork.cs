using DAL.SqlServer.Context;
using DAL.SqlServer.Infrastructure;
using Repository.Common;
using Repository.Repositories;

namespace DAL.SqlServer.UnitOfWork;
public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;
    private readonly string _connectionString = connectionString;

    public IUserRepository _userRepository;
    public IRefreshtokenRepository _refreshTokenRepository;
    public IPostRepository _postRepository;
    public IMessageRepository _messageRepository;
    public ICommentRepository _commentRepository;
    public IUserFollowRequestRepository _userFollowRequestRepository;
    public IUserFollowerRepository _userFollowerRepository;
    public ILikeRepository _likeRepository;


    public IUserRepository UserRepository => _userRepository ?? new SqlUserRepository(_context);

    public IRefreshtokenRepository RefreshTokenRepository => _refreshTokenRepository ?? new SqlRefreshTokenRepository(_context);
    public IPostRepository PostRepository => _postRepository ?? new SqlPostRepository(_context);
    public IMessageRepository MessageRepository => _messageRepository ?? new SqlMessageRepository(_context);
    public ICommentRepository CommentRepository => _commentRepository ?? new SqlCommentRepository(_context);
    public IUserFollowRequestRepository UserFollowRequestRepository => _userFollowRequestRepository ?? new SqlUserFollowRequestRepository(_context);
    public IUserFollowerRepository UserFollowerRepository => _userFollowerRepository ?? new SqlUserFollowerRepository(_context);
    public ILikeRepository LikeRepository => _likeRepository ?? new SqlLikeRepository(_context);
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
