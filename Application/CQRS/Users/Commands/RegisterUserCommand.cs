using Application.CQRS.Users.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

public class RegisterUserCommand : IRequest<Result<RegisterResponseDto>>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; } // Optional
    public string LastName { get; set; }  // Optional
}