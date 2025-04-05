using Application.CQRS.Users.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Users.Commands;

public class LoginUserCommand : IRequest<Result<LoginResponseDto>>
{ 
    public string Email { get; set; }
    public string Password { get; set; }
}

