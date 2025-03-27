using Application.CQRS.Users.DTOs;
using Common.GlobalResponses;
using MediatR;

namespace Application.CQRS.Users.Commands
{
    public class UpdateUserCommand : IRequest<Result>
    {
        public UpdateUserDto User { get; set; }

        public UpdateUserCommand(UpdateUserDto user)
        {
            User = user;
        }
    }
}

