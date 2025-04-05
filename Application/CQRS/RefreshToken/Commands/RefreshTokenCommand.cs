using Application.CQRS.RefreshToken.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.RefreshToken.Commands;

public class RefreshTokenCommand : IRequest<Result<RefreshTokenResponseDto>>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

