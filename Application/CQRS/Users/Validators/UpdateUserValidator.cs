using Application.CQRS.Users.DTOs;
using FluentValidation;

namespace Application.CQRS.Users.Validators;    

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

    }
}
