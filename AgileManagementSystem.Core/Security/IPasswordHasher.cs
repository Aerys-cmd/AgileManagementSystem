﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
