using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{

    public IUserRepository UserRepository { get; }
    public IRefreshtokenRepository RefreshTokenRepository { get; }

    Task<int> SaveChanges();
}
