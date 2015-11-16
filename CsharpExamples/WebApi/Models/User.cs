using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Password { get; set; }

        public IEnumerable<Employee> employees { get; set; }

        public string HashPassword(string password)
        {
            var saltedPass = string.Concat(password, Salt);
            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(saltedPass);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public string GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new Byte[8];
            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public bool ValidatePassword(string password)
        {
            var hash = HashPassword(password);
            return string.Equals(Hash, hash);
        }
        public void Add()
        {
            Salt = GenerateSalt();
            Hash = HashPassword(Password);

        }
    }
}
