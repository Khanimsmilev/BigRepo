using Application.CQRS.Users.DTOs;
using Application.Security;
using Common.GlobalResponses.Generics;
using Common.Security;
using Domain.Entities;
using MediatR;
using Repository.Common;

public class RegisterUserCommandHandler(
    IUnitOfWork unitOfWork,
    ICustomPasswordHasher passwordHasher,
    IEmailSender emailSender) : IRequestHandler<RegisterUserCommand, Result<RegisterResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICustomPasswordHasher _passwordHasher = passwordHasher;
    private readonly IEmailSender _emailSender = emailSender;

    public async Task<Result<RegisterResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);
        if (existingUser is not null)
            return Result<RegisterResponseDto>.Failure("This email is already registered.", "Email is already in use.");

        var passwordHash = _passwordHasher.HashPassword(request.Password, out string passwordSalt);

        var verificationCode = new Random().Next(100000, 999999).ToString();

        var newUser = new User
        {
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            FirstName = request.FirstName,
            LastName = request.LastName,
            IsEmailConfirmed = false,
            EmailConfirmationCode = verificationCode
        };

        await _unitOfWork.UserRepository.AddAsync(newUser);
        await _unitOfWork.SaveChangesAsync();

        await _emailSender.SendEmailAsync(request.Email, "Email Verification", $"Your code is: {verificationCode}");

        return Result<RegisterResponseDto>.Success(new RegisterResponseDto
        {
            Message = "Verification code sent to your email.",
            EmailConfirmationRequired = true
        });
    }
}