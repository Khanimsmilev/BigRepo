using FluentValidation;
using static Application.CQRS.Users.Handlers.Register;

namespace Application.CQRS.Users.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(u => u.Email)
            .NotEmpty()
            .MaximumLength(70)
            .EmailAddress();

        RuleFor(u => u.Password)
            .NotEmpty()
            .MaximumLength(50);

    }

}