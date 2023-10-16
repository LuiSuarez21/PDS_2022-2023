using BuildMe.Application.Services.Interfaces;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace BuildMe.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private const int SaltSize = 16; // 16 bytes = 128 bits

        public string HashPassword(string password)
        {
            var salt = GenerateSalt();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var saltedPassword = new byte[SaltSize + passwordBytes.Length];
            Array.Copy(salt, 0, saltedPassword, 0, SaltSize);
            Array.Copy(passwordBytes, 0, saltedPassword, SaltSize, passwordBytes.Length);

            using SHA256 sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(saltedPassword);
            var saltAndHash = new byte[SaltSize + hash.Length];
            Array.Copy(salt, 0, saltAndHash, 0, SaltSize);
            Array.Copy(hash, 0, saltAndHash, SaltSize, hash.Length);
            return Convert.ToBase64String(saltAndHash);
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            var saltAndHash = Convert.FromBase64String(hashedPassword);
            var salt = new byte[SaltSize];
            var hash = new byte[saltAndHash.Length - SaltSize];
            Array.Copy(saltAndHash, 0, salt, 0, SaltSize);
            Array.Copy(saltAndHash, SaltSize, hash, 0, hash.Length);

            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var saltedPassword = new byte[SaltSize + passwordBytes.Length];
            Array.Copy(salt, 0, saltedPassword, 0, SaltSize);
            Array.Copy(passwordBytes, 0, saltedPassword, SaltSize, passwordBytes.Length);

            using SHA256 sha256 = SHA256.Create();
            var computedHash = sha256.ComputeHash(saltedPassword);
            return StructuralComparisons.StructuralEqualityComparer.Equals(hash, computedHash);
        }

        private static byte[] GenerateSalt()
        {
            var randomNumber = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];
            randomNumber.GetBytes(salt);
            return salt;
        }
    }
}