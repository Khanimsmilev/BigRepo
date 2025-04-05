using Domain.Entities;

namespace Repository.Repositories;

public interface ILikeRepository
{
    Task AddAsync(Like like);
    Task RemoveAsync(Like like);
    Task<Like?> GetByUserAndPostAsync(int userId, int postId);
    Task<Like?> GetByUserAndCommentAsync(int userId, int commentId);

    Task<List<Like>> GetLikesByPostIdAsync(int postId);

    Task SaveChangesAsync();
}