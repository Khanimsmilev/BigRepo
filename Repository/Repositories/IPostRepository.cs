using Domain.Entities;

namespace Repository.Repositories;
public interface IPostRepository
{
    Task<Post?> GetByIdAsync(int id);
    Task<List<Post>> GetByUserIdAsync(int userId);
    Task<List<Post>> GetAllAsync();
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Post post);
}