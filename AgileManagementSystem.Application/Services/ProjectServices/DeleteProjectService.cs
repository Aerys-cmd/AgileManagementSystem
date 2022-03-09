using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Events;
using AgileManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.ProjectServices
{

    public class DeleteProjectRequestDto
    {
        public string ProjectId { get; set; }
    }
    public class DeleteProjectResponseDto
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }

    }




    public class DeleteProjectService : IApplicationService<DeleteProjectRequestDto, DeleteProjectResponseDto>
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public DeleteProjectResponseDto OnProcess(DeleteProjectRequestDto request = null)
        {
            var project = _projectRepository.Find(request.ProjectId);
            //projenin contributorlarına projenin silindiğine dair mail at

            _projectRepository.Remove(request.ProjectId);
            var contributorMails = project.Contributors.Select(x => x.Email).ToList();
            DomainEvent.Raise(new ProjectDeletedEvent(project.Name, contributorMails));
            _projectRepository.Save();

            return new DeleteProjectResponseDto
            {
                IsSucceeded = true,
                Message = "Proje silindi."
            };

        }
    }
}
