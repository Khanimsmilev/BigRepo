namespace Application.Security;

public interface IEmailSender
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}

