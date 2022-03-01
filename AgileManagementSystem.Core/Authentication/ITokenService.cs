using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Authentication
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireSeconds { get; set; }
    }
    public interface ITokenService
    {
        Task<TokenResponse> GenerateTokenAsync(IEnumerable<Claim> claims);

        Task<IEnumerable<Claim>> ValidateAccessTokenAsync(string accessToken);
    }
}
