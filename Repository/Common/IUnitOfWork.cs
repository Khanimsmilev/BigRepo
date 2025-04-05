using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{

    public IUserRepository UserRepository { get; }
    public IRefreshtokenRepository RefreshTokenRepository { get; }
    public IPostRepository PostRepository { get; }
    public IMessageRepository MessageRepository { get; }
    public ICommentRepository CommentRepository { get; }
    public IUserFollowerRepository UserFollowerRepository { get; }
    public IUserFollowRequestRepository UserFollowRequestRepository { get; }
    public ILikeRepository LikeRepository { get; }

    Task<int> SaveChangesAsync();
}
    