using Application.CQRS.Users.DTOs;
using MediatR;

namespace Application.CQRS.Users.Queries
{
    public class GetUserByIdQuery(int userId) : IRequest<UserDto>
    {
        public int UserId { get; set; } = userId;
    }
}
