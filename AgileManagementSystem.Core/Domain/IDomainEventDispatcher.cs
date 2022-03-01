﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// Bu sınıf bir event raise olduktan sonra eventin ilgili handler'a sevk edilmesinden sorumlu olan ara bir yapı görevi görür. Böylece event üzerinden taşınan bilgileri bağımsız bir şekilde sisteme tanımlanmış olan Handler'a iletmekten sorumludur.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IDomainEventDispatcher
    {
        void Dispatch<TDomainEvent>(TDomainEvent @event) where TDomainEvent:IDomainEvent;
    }
}
