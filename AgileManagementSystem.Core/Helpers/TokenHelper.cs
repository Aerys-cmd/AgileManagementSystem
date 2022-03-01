using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Services
{
    /// <summary>
    /// Access Token Expire olduğunda üretilecek olan bir string base64 formatında kod. Bunu oluşturan user'ın hesabında refresh token bilgisini saklarız. ve access token expire olduğunda gidip bu refresh token bu kullanıcı için oluşmuş mu kontrolü yaparak yeni bir access token üretilmesini sağlarız.
    /// </summary>
    public static class TokenHelper
    {
        public static string GetToken()
        {
            var randomNumber = new byte[32];
            string token = "";
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }
            return token;
        }
    }
}
