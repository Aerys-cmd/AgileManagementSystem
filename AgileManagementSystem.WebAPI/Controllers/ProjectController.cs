using AgileManagementSystem.Application.Services.ProjectServices;
using Microsoft.AspNetCore.Authorization;
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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectAddService _projectAddService;
        public ProjectController(ProjectAddService projectAddService)
        {
            _projectAddService = projectAddService;
        }
        [HttpPost("add-project")][Authorize]
        public IActionResult AddProject(ProjectAddRequestDto request)
        {
            var response = _projectAddService.OnProcess(request);
            if (response.IsSucceeded)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }
    }
}
