using System.Security.Cryptography;
using BlogPost.Application.Abstractions;

namespace BlogPost.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    private static int SaltSize = 16;
    private static int Iterations = 100_000;
    private static int HashSize = 32;
    private static HashAlgorithmName Algorithm = HashAlgorithmName.SHA3_512;

    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        var parts = hashedPassword.Split('-');
        var hash = Convert.FromHexString(parts[0]);
        var salt = Convert.FromHexString(parts[1]);
        
        var inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
        
        return hash.SequenceEqual(inputHash);
    }
}