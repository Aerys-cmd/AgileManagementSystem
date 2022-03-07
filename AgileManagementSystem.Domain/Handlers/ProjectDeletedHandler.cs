using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Core.Notification;
using AgileManagementSystem.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Handlers
{
    public class ProjectDeletedHandler : IDomainEventHandler<ProjectDeletedEvent>
    {
        private readonly IEmailService _emailService;
        public ProjectDeletedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void Handle(ProjectDeletedEvent @event)
        {
            foreach (var email in @event.ContributorEmails)
            {
                _emailService.SendSingleEmailAsync(email, $"{@event.ProjectName} Proje silindi", $"{@event.ProjectName} isimli proje proje sahibi tarafından silindi. Artık bu projeye katkı sağlayamayacaksınız :(");
            }
        }
    }
}
