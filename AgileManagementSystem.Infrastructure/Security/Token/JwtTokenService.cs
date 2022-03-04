using AgileManagementSystem.Core.Authentication;
using AgileManagementSystem.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Infrastructure.Security.Token
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<TokenResponse> GenerateTokenAsync(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken
               (
                   issuer: _configuration["JWT:issuer"],
                   audience: _configuration["JWT:audience"],
                   claims: claims,
                   expires: DateTime.UtcNow.AddSeconds(3600),
                   notBefore: DateTime.UtcNow,
                   signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:signingKey"])),
                           SecurityAlgorithms.HmacSha512)


               );

            var model = new TokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = TokenHelper.GetToken(),
                ExpireSeconds = 3600
            };

            return await Task.FromResult(model);
        }

        public Task<IEnumerable<Claim>> ValidateAccessTokenAsync(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {

                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:signingKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);


            return Task.FromResult(principal.Claims);
        }
    }
}
