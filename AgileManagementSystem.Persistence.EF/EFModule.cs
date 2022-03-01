using AgileManagementSystem.Domain.Repositories;
using AgileManagementSystem.Persistence.EF.Contexts;
using AgileManagementSystem.Persistence.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Persistence.EF
{
    public static class EFModule
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalDb"));
            });
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IProjectRepository, EFProjectRepository>();

        }
    }
}
