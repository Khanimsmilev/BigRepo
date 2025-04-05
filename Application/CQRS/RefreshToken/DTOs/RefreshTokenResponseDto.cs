namespace Application.CQRS.RefreshToken.DTOs;

public class RefreshTokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
}
