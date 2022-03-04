using AgileManagementSystem.Application.Services.Verify;
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
    public class VerifyController : ControllerBase
    {
        private readonly UserVerifyMailService _userVerifyMailService;
        public VerifyController(UserVerifyMailService userVerifyMailService)
        {
            _userVerifyMailService = userVerifyMailService;
        }

        [HttpPost("verify-email")]
        public IActionResult VerifyUserEmail(UserVerifyEmailRequestDto model)
        {
            var response = _userVerifyMailService.OnProcess(model);

            if (response.IsSucceeded)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }
    }
}
