using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Events
{
    public class ProjectDeletedEvent : IDomainEvent
    {
        public ProjectDeletedEvent(string projectName, List<string> contributorEmails)
        {
            ProjectName = projectName;
            ContributorEmails = contributorEmails;
        }

        public string ProjectName { get; set; }

        public List<string> ContributorEmails { get; set; }

        public string Name { get; set; } = "ProjectDeletedEvent";
    }
}
