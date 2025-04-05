using Common.GlobalResponses;
using MediatR;

public class ConfirmEmailCommand : IRequest<Result>
{
    public string Email { get; set; }
    public string Code { get; set; }
}