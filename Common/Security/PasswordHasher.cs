using Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security;

public class PasswordHasher : ICustomPasswordHasher
{
    public string HashPassword(string password, out string salt)
    {
        salt = GenerateSalt();
        return ComputeSha256Hash(password, salt);
    }


    public bool VerifyHashedPassword(string password, string salt, string hashedPassword)
    {
        var hashOfInput = ComputeSha256Hash(password, salt);
        return hashOfInput == hashedPassword;
    }

    private string ComputeSha256Hash(string input, string salt)
    {
        using var sha256 = SHA256.Create();
        var combined = Encoding.UTF8.GetBytes(input + salt);
        var hash = sha256.ComputeHash(combined);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    private string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
}