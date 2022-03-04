using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Authentication;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.ProjectServices
{

    public class ProjectAddRequestDto
    {
        /// <summary>
        /// Proje ismi
        /// </summary>

        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Proje Açıklaması
        /// </summary>
        public string Description { get; set; }


    }
    public class ProjectAddResponseDto
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }
    public class ProjectAddService : IApplicationService<ProjectAddRequestDto, ProjectAddResponseDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        public ProjectAddService(IProjectRepository projectRepository, IAuthenticatedUserService authenticatedUserService)
        {
            _projectRepository = projectRepository;
        }
        public ProjectAddResponseDto OnProcess(ProjectAddRequestDto request = null)
        {
            try
            {
                var project = new Project(request.Name, request.Description, _authenticatedUserService.GetUser.Id);
                _projectRepository.Add(project);
                _projectRepository.Save();

                return new ProjectAddResponseDto
                {
                    IsSucceeded = true,
                    Message = "Başarıyla eklendi"
                };
            }
            catch (Exception ex)
            {
                return new ProjectAddResponseDto
                {
                    IsSucceeded = false,
                    Message = ex.Message
                };

            }

        }
    }
}
