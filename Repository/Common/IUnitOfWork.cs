using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{

    public IUserRepository UserRepository { get; }
    public IRefreshtokenRepository RefreshTokenRepository { get; }
    public IPostRepository PostRepository { get; }
    public IMessageRepository MessageRepository { get; }

    Task<int> SaveChangesAsync();
}
