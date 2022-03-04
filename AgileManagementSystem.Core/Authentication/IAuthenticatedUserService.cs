using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Authentication
{
    public class AuthenticatedUser
    {
        public string Email { get; set; }
        public string Id { get; set; }

    }
    public interface IAuthenticatedUserService
    {
        AuthenticatedUser GetUser { get; }
    }
}
