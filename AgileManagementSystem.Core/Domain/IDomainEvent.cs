﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// Gerçekleşecek olay ile ilgili bir interface tanımladım. Entity içerisinde bir state değerinde bir değişim sonucu bu event başka bir entity haber vericek. FiyatDeğiştiğinde Bu ürünü favorisine eklemiş olan kullanıcılara e-posta gönderme gibi. Sisteme makale girildiğinde takip edilen yazarın son makalesini e-posta olarak alma.
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// ismi ne olan eventin fırlatıldığını bulmak için elimizde tutuyoruz.
        /// </summary>
        public string Name { get; set; } // EventName, OrderedEvent,ShippedEvent,PriceChanged
    }
}
