namespace Application.CQRS.Users.DTOs;
public class RefreshTokenDto
{
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}