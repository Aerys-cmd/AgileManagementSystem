using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Events
{
    public class ContributorSendAccessRequestEvent : IDomainEvent
    {
        public ContributorSendAccessRequestEvent(string contributorEmail, string projectId, string projectName)
        {
            ContributorEmail = contributorEmail;
            ProjectId = projectId;
            ProjectName = projectName;
        }

        public string ContributorEmail { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Name { get; set; } = "ContributorSendAccessRequestEvent";
    }
}
