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


    public IUserRepository UserRepository => _userRepository ??= new SqlUserRepository(_context);

    public IRefreshtokenRepository RefreshTokenRepository => _refreshTokenRepository ??= new SqlRefreshTokenRepository(_context);
    public IPostRepository PostRepository => _postRepository ??= new SqlPostRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
