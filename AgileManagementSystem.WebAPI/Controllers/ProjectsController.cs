using AgileManagementSystem.Application.Services.ProjectServices;
using AgileManagementSystem.Core.Authentication;
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
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectAddService _projectAddService;
        private readonly SendContributorProjectAccessService _sendContributorProjectAccessService;
        private readonly DeleteProjectService _deleteProjectService;
        private readonly GetUsersProjectsService _getUsersProjectsService;
        public ProjectsController(ProjectAddService projectAddService, SendContributorProjectAccessService sendContributorProjectAccessService, DeleteProjectService deleteProjectService, GetUsersProjectsService getUsersProjectsService)
        {
            _deleteProjectService = deleteProjectService;
            _projectAddService = projectAddService;
            _sendContributorProjectAccessService = sendContributorProjectAccessService;
            _getUsersProjectsService = getUsersProjectsService;
        }
        [HttpPost("add-project")]
        [Authorize]
        public IActionResult AddProject(ProjectAddRequestDto request)
        {
            var response = _projectAddService.OnProcess(request);
            if (response.IsSucceeded)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }

        [HttpPost("send-project-access")]
        [Authorize]
        public IActionResult SendContributorProjectAccess(SendContributorProjectAccessRequestDto request)
        {
            var response = _sendContributorProjectAccessService.OnProcess(request);
            if (response.IsSucceeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("delete-project")]
        [Authorize]
        public IActionResult DeleteProject(DeleteProjectRequestDto request)
        {
            var response = _deleteProjectService.OnProcess(request);
            if (response.IsSucceeded)
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpGet("get-users-projects")]
        public IActionResult GetUsersProjects()
            {
            var response = _getUsersProjectsService.OnProcess();
            if (response.IsSucceeded)
            {
                return Ok(response);
            }

            return BadRequest();
        }

     



    }
}
