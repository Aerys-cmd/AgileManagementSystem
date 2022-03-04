using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public UserCreatedEvent(string userId, string email)
        {
            UserId = userId;
            Email = email;
        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; } = "UserCreatedEvent";
    }
}
