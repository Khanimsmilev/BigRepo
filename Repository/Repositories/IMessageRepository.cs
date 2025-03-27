using Domain.Entities;

namespace Repository.Repositories;

public interface IMessageRepository
{
    IQueryable<Message> GetAll();
    Task<Message?> GetByIdAsync(int messageId);
    IQueryable<Message> GetByUserId(int userId);
    IQueryable<Message> GetConversation(int userId1, int userId2);

    Task<Message> AddAsync(Message message);
    Task UpdateAsync(Message message);
}
