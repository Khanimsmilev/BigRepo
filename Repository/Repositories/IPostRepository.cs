using Domain.Entities;

namespace Repository.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(int id);
        IQueryable<Post> GetAll();
        IQueryable<Post> GetByUserId(int userId);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
    }
}
