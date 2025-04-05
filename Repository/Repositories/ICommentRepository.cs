using Domain.Entities;

namespace Repository.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment);
    Task<Comment?> GetByIdAsync(int id);
    Task<List<Comment>> GetByPostIdAsync(int postId);
    Task DeleteAsync(Comment comment);
}

