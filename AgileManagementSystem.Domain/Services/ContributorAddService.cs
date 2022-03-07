using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Services
{
    public class ContributorAddService : IContributorAddService
    {
        private readonly IProjectRepository _projectRepository;
        public ContributorAddService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void AddContributor(Contributor contributor, Project project)
        {
            var existingContributor = _projectRepository.GetQuery().Include(x => x.Contributers).SelectMany(x => x.Contributers).FirstOrDefault(x => x.Email == contributor.Email);
            if (existingContributor == null)
            {
                project.AddContributor(contributor);
            }
            project.AddContributor(existingContributor);
        }
    }
}
