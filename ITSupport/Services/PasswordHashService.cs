using System;
using System.Security.Cryptography;
using System.Text;

namespace ITSupport.Services
{
    public class PasswordHashService
    {
        public static string HashPassword(string password)
        {
            // Generate a salt
            using (var hmac = new HMACSHA256())
            {
                var salt = hmac.Key;
                // Hash the password with PBKDF2
                using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000))
                {
                    var hash = rfc2898.GetBytes(20);
                    // Combine salt and hash for storage
                    var hashBytes = new byte[36];
                    Array.Copy(salt, 0, hashBytes, 0, 16);
                    Array.Copy(hash, 0, hashBytes, 16, 20);
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            // Extract the bytes from the storedHash
            var hashBytes = Convert.FromBase64String(storedHash);
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var storedSubKey = new byte[20];
            Array.Copy(hashBytes, 16, storedSubKey, 0, 20);

            // Hash the input password
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                var computedHash = rfc2898.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {
                    if (computedHash[i] != storedSubKey[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}