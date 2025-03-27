using Common.GlobalResponses;
using MediatR;

namespace Application.CQRS.Users.Commands
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public int UserId { get; set; }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}

