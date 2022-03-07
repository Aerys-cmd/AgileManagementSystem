using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using AgileManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.Verify
{
    public class AcceptProjectAccessRequestDto
    {
        public string ProjectId { get; set; }
        public string ContributorEmail { get; set; }
    }

    public class AcceptProjectAccessResponseDto
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }
    public class AcceptProjectAccessService : IApplicationService<AcceptProjectAccessRequestDto, AcceptProjectAccessResponseDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IContributorAddService _contributorAddService;
        public AcceptProjectAccessService(IProjectRepository projectRepository, IContributorAddService contributorAddService)
        {
            _contributorAddService = contributorAddService;
            _projectRepository = projectRepository;
        }
        public AcceptProjectAccessResponseDto OnProcess(AcceptProjectAccessRequestDto request = null)
        {
            if (request == null)
            {
                return new AcceptProjectAccessResponseDto
                {
                    IsSucceeded = false,
                    Message = "İstek düzgün formatta değil."
                };
            }

            var project = _projectRepository.Find(request.ProjectId);

            var contributor = new Contributor(request.ContributorEmail);
            _contributorAddService.AddContributor(contributor, project);

            return new AcceptProjectAccessResponseDto
            {
                IsSucceeded = true,
                Message = "Contributor eklendi."
            };
        }
    }
}
