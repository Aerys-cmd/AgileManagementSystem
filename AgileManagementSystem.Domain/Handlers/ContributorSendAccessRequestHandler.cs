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
    public class ContributerSendAccessRequestHandler : IDomainEventHandler<ContributorSendAccessRequestEvent>
    {
        private readonly IEmailService _emailService;

        public ContributerSendAccessRequestHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Handle(ContributorSendAccessRequestEvent @event)
        {

            string activationLink = "http://localhost:3000/AcceptRequest?projectId=" + @event.ProjectId + "&contributorMail=" + @event.ContributorEmail;

            _emailService.SendSingleEmailAsync(@event.ContributorEmail, $"{@event.ProjectName} için erişim izni isteği", $"<p> Projeye erişimi Kabul etmek için <a href='{activationLink}&accepted=true'> Tıklaynız <a/></p>");

        }
    }
}
