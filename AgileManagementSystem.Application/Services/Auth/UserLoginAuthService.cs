using AgileManagement.Core.Helpers;
using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Authentication;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.Auth
{
    public class UserLoginAuthRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginAuthResponseDto
    {
        public bool IsSucceeded { get; set; }
        public TokenResponse TokenResponse { get; set; }
    }
    public class UserLoginAuthService : IApplicationService<UserLoginAuthRequestDto, Task<UserLoginAuthResponseDto>>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public UserLoginAuthService(ITokenService tokenService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserLoginAuthResponseDto> OnProcess(UserLoginAuthRequestDto request = null)
        {
            var user = _userRepository.GetQuery().Where(x => x.Email == request.Email && x.PasswordHash == CustomPasswordHashService.HashPassword(request.Password)).FirstOrDefault();
            if (user == null) return await Task.FromResult(new UserLoginAuthResponseDto
            {
                IsSucceeded = false
            });
            var claims = new List<Claim>
                {
                    new Claim("id",user.Id),
                    new Claim("email",user.Email),
                };

            var tokenResponse = await _tokenService.GenerateTokenAsync(claims);
            var userToken = new UserToken(tokenResponse.AccessToken, tokenResponse.RefreshToken);
            user.AddUserToken(userToken);

            return await Task.FromResult(new UserLoginAuthResponseDto
            {
                IsSucceeded = true,
                TokenResponse = tokenResponse
            }); ;
        }
    }
}
