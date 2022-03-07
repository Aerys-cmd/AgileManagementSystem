using AgileManagementSystem.Application.Dtos;
using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Authentication;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.ProjectServices
{
    public class GetUsersProjectsRequestDto
    {
    }
    public class GetUsersProjectsResponseDto
    {
        public bool IsSucceeded { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public string Message { get; set; }

    }
    public class GetUsersProjectsService : IApplicationService<GetUsersProjectsRequestDto, GetUsersProjectsResponseDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        public GetUsersProjectsService(IProjectRepository projectRepository, IAuthenticatedUserService authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
            _projectRepository = projectRepository;
        }
        public GetUsersProjectsResponseDto OnProcess(GetUsersProjectsRequestDto request = null)
        {
            var usersProjects = _projectRepository.GetQuery().Where(x => x.CreatedBy == _authenticatedUserService.GetUser.Id).ToList();
            if (usersProjects == null)
            {
                return new GetUsersProjectsResponseDto
                {
                    IsSucceeded = true,
                    Message = "Kullanıcının projesi bulunamadı",
                    Projects = new List<ProjectDto>()

                };
            }

            var response = new GetUsersProjectsResponseDto
            {
                IsSucceeded = true,
                Message = "Gönderildi",
                Projects = usersProjects.Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name

                }).ToList()
            };

            return response;
        }
    }
}
