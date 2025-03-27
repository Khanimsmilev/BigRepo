using Application.CQRS.Users.DTOs;
using MediatR;

namespace Application.CQRS.Users.Queries;

public class GetUserByEmailQuery : IRequest<GetUserByEmailResponse>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}

