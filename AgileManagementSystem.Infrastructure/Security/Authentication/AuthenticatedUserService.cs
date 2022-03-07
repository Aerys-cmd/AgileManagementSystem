using AgileManagementSystem.Core.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Infrastructure.Security.Authentication
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public AuthenticatedUser GetUser { get {

                return new AuthenticatedUser
                {
                    Email = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "mail").Value,
                    Id = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value
                };
            } }
    }
}
