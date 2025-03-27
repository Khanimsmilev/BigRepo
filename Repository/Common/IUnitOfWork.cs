using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{

    public IUserRepository UserRepository { get; }
    public IRefreshtokenRepository RefreshTokenRepository { get; }
    public IPostRepository PostRepository { get; }

    Task<int> SaveChangesAsync();
}
