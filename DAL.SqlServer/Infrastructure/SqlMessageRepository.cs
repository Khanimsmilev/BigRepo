using DAL.SqlServer.Context;
using Domain.Entities;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlMessageRepository : IMessageRepository
{
    private readonly AppDbContext _context;

    public SqlMessageRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Message> GetAll()
    {
        return _context.Messages.AsQueryable();
    }

    public async Task<Message?> GetByIdAsync(int messageId)
    {
        return await _context.Messages.FindAsync(messageId);
    }

    public IQueryable<Message> GetByUserId(int userId)
    {
        return _context.Messages
            .Where(m => m.SenderId == userId || m.ReceiverId == userId);
    }

    public IQueryable<Message> GetConversation(int userId1, int userId2)
    {
        return _context.Messages
            .Where(m => (m.SenderId == userId1 && m.ReceiverId == userId2) ||
                        (m.SenderId == userId2 && m.ReceiverId == userId1))
            .OrderBy(m => m.CreatedDate);
    }

    public async Task<Message> AddAsync(Message message)
    {
        message.CreatedDate = DateTime.UtcNow;
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return message;
    }

    public async Task UpdateAsync(Message message)
    {
        message.UpdatedDate = DateTime.UtcNow;
        _context.Messages.Update(message);
        await _context.SaveChangesAsync();
    }
}
