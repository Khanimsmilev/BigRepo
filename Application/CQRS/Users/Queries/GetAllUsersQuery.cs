using Application.CQRS.Users.DTOs;
using MediatR;

namespace Application.CQRS.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<GetUserByIdResponse>>
    {
    }
}
