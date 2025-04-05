using Application.CQRS.Users.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Users.Commands;

public class CreateUserCommand : IRequest<Result<CreateUserResponseDto>>
{
    public CreateUserDto User { get; set; }

    public CreateUserCommand(CreateUserDto user)
    {
        User = user;
    }
}
