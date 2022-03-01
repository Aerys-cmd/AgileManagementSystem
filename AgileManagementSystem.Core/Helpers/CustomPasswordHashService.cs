using System.Security.Cryptography;
using System.Text;

namespace AgileManagement.Core.Helpers
{
    public static class CustomPasswordHashService
    {
        public static string HashPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arrays = Encoding.UTF8.GetBytes(password);
            arrays = md5.ComputeHash(arrays);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in arrays)
            {
                // 16lık sayi ssisteminde byte çevir 
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

    }
}
