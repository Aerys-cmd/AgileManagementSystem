using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
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
    public class AcceptProjectAccessService : IApplicationService<AcceptProjectAccessRequestDto, AcceptProjectAccessRequestDto>
    {
        private readonly IProjectRepository _projectRepository;
        public AcceptProjectAccessService(IProjectRepository projectRepository)
        {
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


            var existingContributor = _projectRepository.GetQuery().Include(x => x.Contributers).SelectMany(x => x.Contributers).FirstOrDefault(x => x.Email == request.ContributorEmail);
            if (existingContributor == null)
            {
                existingContributor = new Contributor(request.ContributorEmail);
            }
            project.AddContributor(existingContributor);
        }
    }
}
