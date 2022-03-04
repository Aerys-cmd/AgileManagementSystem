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
        private readonly UserRegisterService _userRegisterService;

        public AuthController(UserLoginAuthService loginAuthService, UserLoginRefreshTokenAuthService refreshTokenAuthService, UserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
            _loginAuthService = loginAuthService;
            _refreshTokenAuthService = refreshTokenAuthService;
        }
        [HttpPost("userregister")]
        public IActionResult Register(UserRegisterRequestDto model)
        {
            var response = _userRegisterService.OnProcess(model);
            if (response.IsSucceeded)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }

        [HttpPost("get-token")]
        public async Task<IActionResult> Token(UserLoginAuthRequestDto model)
        {


            var response = await _loginAuthService.OnProcess(model);
            if (!response.IsSucceeded) return BadRequest();

            return Ok(response.TokenResponse);

        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto model)
        {
            var response = await _refreshTokenAuthService.OnProcess(model);
            if (!response.IsSucceeded) return BadRequest();

            return Ok(response.TokenResponse);

        }
    }
}
