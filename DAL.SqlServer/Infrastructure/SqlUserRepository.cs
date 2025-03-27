using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public SqlUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return;//user tapilmasa hec ne etmirik

            user.IsDeleted = true;
            user.DeletedDate = DateTime.Now;
            user.DeletedBy = 0;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            user.UpdatedDate = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
