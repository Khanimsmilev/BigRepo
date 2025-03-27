using Domain.Entities;

namespace Repository.Repositories;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(int id);
    Task<List<User>> GetAll(); // bunu da deyisib IQueryable edecem, helelik bele yazdim
    //IQueryable<User> GetAll(); 
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
}
