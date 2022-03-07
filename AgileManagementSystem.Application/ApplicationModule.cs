using AgileManagementSystem.Application.Services.Auth;
using AgileManagementSystem.Application.Services.ProjectServices;
using AgileManagementSystem.Application.Services.Verify;
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

            services.AddScoped<UserLoginRefreshTokenAuthService>();

            services.AddScoped<UserRegisterService>();

            services.AddScoped<UserVerifyMailService>();
            services.AddScoped<ProjectAddService>();

            services.AddScoped<DeleteProjectService>();
            services.AddScoped<GetUsersProjectsService>();
            services.AddScoped<SendContributorProjectAccessService>();
            services.AddScoped<AcceptProjectAccessService>();

        }
    }
}
