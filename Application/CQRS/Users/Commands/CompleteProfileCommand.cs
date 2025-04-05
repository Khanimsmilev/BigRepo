using Common.GlobalResponses;
using MediatR;

public class CompleteProfileCommand : IRequest<Result>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Location { get; set; }
    public string CurrentJobTitle { get; set; }
    public string CurrentCompany { get; set; }
}