using System.Security.Cryptography;
using System.Text;
using Toolbox.Core.Interfaces;

namespace Toolbox.Infrastructure.Security
{
    public class PasswordHandler : IPasswordHandler
    {
        public string GenerateSalt(int length = 16)
        {
            var bytes = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
        public string HashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password + salt);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
