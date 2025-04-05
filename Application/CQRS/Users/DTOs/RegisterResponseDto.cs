namespace Application.CQRS.Users.DTOs
{
    public class RegisterResponseDto
    {
        public string Message { get; set; }
        public bool EmailConfirmationRequired { get; set; }
    }
}
