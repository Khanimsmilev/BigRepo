using Application.CQRS.Users.DTOs;
using MediatR;

namespace Application.CQRS.Users.Queries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
