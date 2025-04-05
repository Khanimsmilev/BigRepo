using Domain.Entities;

namespace Repository.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(int id, int currentUserId);
    Task<List<User>> GetAllAsync(); 
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
}
