using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Events;
using AgileManagementSystem.Domain.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain
{
    public static class DomainModule
    {
        public static void Load(IServiceCollection services)
        {
            // event handlerlar her çağrıldığında sistem tarafından yeni bir instance alınsın.
            services.AddTransient<IDomainEventHandler<ContributorSendAccessRequestEvent>, ContributerSendAccessRequestHandler>();
            services.AddTransient<IDomainEventHandler<UserCreatedEvent>, UserCreatedHandler>();
        }
    }
}
