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
    public class UserCreatedHandler : IDomainEventHandler<UserCreatedEvent>
    {
        private readonly IEmailService _emailService;
        public UserCreatedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void Handle(UserCreatedEvent @event)
        {
            string activationLink = "http://localhost:3000/VerifyMail?userId=" + @event.UserId;
            _emailService.SendSingleEmailAsync(@event.Email, $"Email onayı", $"<p> Emaili onaylamak için <a href='{activationLink}&accepted=true'> Tıklaynız <a/></p>");
        }
    }
}
