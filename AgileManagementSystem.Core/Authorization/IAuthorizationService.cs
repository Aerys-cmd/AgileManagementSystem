using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Authorization
{
    public interface IAuthorizationService
    {
        Task<bool> IsAuthorized(string email,params string[] roles);
    }
}
