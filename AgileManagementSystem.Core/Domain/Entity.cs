﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Domain
{
    /// <summary>
    /// Bu sınıftan instance alınamaz ama diğer sınıflar bu sınıftan instance alıp entity özelliği kazanacaklar. Her entity id si olduğu için bu sınıf içerisine koyduk. Entitylerin hepsi event fırlatabilir oluyor. işi bitince eventi fırlatıp içi başka bir nesneye bırakacağız.
    /// </summary>
    public abstract class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }

}
