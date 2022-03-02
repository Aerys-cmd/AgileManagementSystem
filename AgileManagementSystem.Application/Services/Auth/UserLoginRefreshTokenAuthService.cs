using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Authentication;
using AgileManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.Auth
{
    public class RefreshTokenRequestDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
    public class UserLoginRefreshTokenAuthService : IApplicationService<RefreshTokenRequestDto, Task<UserLoginAuthResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserLoginRefreshTokenAuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserLoginAuthResponseDto> OnProcess(RefreshTokenRequestDto request = null)
        {
            var user = _userRepository.GetQuery().FirstOrDefault(x => x.RefreshToken == request.RefreshToken);

            if (user == null) return await Task.FromResult(new UserLoginAuthResponseDto
            {
                IsSucceeded = false,
            });

            var claims = await _tokenService.ValidateAccessTokenAsync(request.AccessToken);

            var tokenResponse = await _tokenService.GenerateTokenAsync(claims);

            user.SetRefreshToken(tokenResponse.RefreshToken);
            _userRepository.Save();

            return await Task.FromResult(new UserLoginAuthResponseDto
            {
                IsSucceeded = true,
                TokenResponse = tokenResponse
            });


        }
    }
}
