﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// Bu sınıfı IOC ile singleton bir instance'a bağlayacağız uygulama ilk ayağa kalktığında bu dispatcher sınıfı static tanımlamamızın sebebi tek bir instance ile uygulama genelinde bu sevk edici arkadaşı çalıştırmak. IOC üzerinden tanımlanmış tüm handlerlara dispatcher üzerindeki Dispatch methodu ile erip tetiklenmelerini sağlayacağız. Fakat bunu bu katmanda değil uygulamanın Infrastructre katmanında yapacağız.
    /// </summary>
    public static class DomainEvent
    {
        public static IDomainEventDispatcher Dispatcher { get; set; } 

       
        public static void Raise<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent
        {

            Dispatcher.Dispatch(@event);
        }
    }
}
