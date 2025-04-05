using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Users.Commands;

public class DeleteUserCommand : IRequest<Result<string>>
{
/*    public int UserId { get; set; }

    public DeleteUserCommand(int userId)
    {
        UserId = userId;
    }*/
}

