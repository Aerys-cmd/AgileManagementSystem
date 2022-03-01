using AgileManagementSystem.Core.Data;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using AgileManagementSystem.Persistence.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Persistence.EF.Repositories
{
    public class EFProjectRepository : EFBaseRepository<Project, AppDbContext>,IProjectRepository
    {
        public EFProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
