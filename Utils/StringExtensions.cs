using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class StringExtensions
    {
        public static byte[] Hash(this string str)
        {
            using (var hash = SHA256.Create())
            {
                var encoding = Encoding.UTF8;
                return hash.ComputeHash(encoding.GetBytes(str));
            }
        }
    }
}
