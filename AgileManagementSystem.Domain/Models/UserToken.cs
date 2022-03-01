using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Models
{
    public class UserToken : Entity
    {
        public UserToken(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpireDate = DateTime.UtcNow.AddSeconds(7200);
        }

        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime ExpireDate { get; private set; }
    }
}
