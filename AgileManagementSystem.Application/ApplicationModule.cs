using AgileManagementSystem.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application
{
    public static class ApplicationModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<UserLoginAuthService>();
        }
    }
}
