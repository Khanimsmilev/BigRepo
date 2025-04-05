namespace Common.Security;

public interface ICustomPasswordHasher
{
    string HashPassword(string password, out string salt);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword, string salt);
}
