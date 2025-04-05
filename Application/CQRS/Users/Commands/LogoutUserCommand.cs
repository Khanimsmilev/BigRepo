using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Users.Commands;

public class LogoutUserCommand : IRequest<Result<string>>
{
    public string RefreshToken { get; set; }
}
