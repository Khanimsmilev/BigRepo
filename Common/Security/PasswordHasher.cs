using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher : IPasswordHasher<User>
{
    public string HashPassword(User user, string password)
    {
        var salt = GenerateSalt();
        user.PasswordSalt = salt;
        return ComputeStringToSha256Hash(password, salt);
    }

    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        string hashOfInput = ComputeStringToSha256Hash(providedPassword, user.PasswordSalt);

        if (hashOfInput == hashedPassword)
            return PasswordVerificationResult.Success; 

        return PasswordVerificationResult.Failed;
    }

    public static string ComputeStringToSha256Hash(string plainText, string salt)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText + salt));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }

    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
}
