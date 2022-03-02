using AgileManagementSystem.Application.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserLoginAuthService _loginAuthService;
        private readonly UserLoginRefreshTokenAuthService _refreshTokenAuthService;

        public AuthController(UserLoginAuthService loginAuthService, UserLoginRefreshTokenAuthService refreshTokenAuthService)
        {
            _loginAuthService = loginAuthService;
            _refreshTokenAuthService = refreshTokenAuthService;
        }

        public async Task<IActionResult> Token(UserLoginAuthRequestDto model)
        {
            var response = await _loginAuthService.OnProcess(model);
            if (!response.IsSucceeded) return BadRequest();

            return Ok(response.TokenResponse);

        }

        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto model)
        {
            var response = await _refreshTokenAuthService.OnProcess(model);
            if (!response.IsSucceeded) return BadRequest();

            return Ok(response.TokenResponse);

        }
    }
}
