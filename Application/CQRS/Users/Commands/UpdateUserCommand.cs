using Application.CQRS.Users.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Users.Commands;

public class UpdateUserCommand : IRequest<Result<string>>
{
    public UpdateUserDto Dto { get; set; }

    public UpdateUserCommand(UpdateUserDto dto)
    {
        Dto = dto;
    }
}

