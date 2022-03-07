using AgileManagementSystem.Core.Data;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using AgileManagementSystem.Persistence.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Persistence.EF.Repositories
{
    public class EFProjectRepository : EFBaseRepository<Project, AppDbContext>, IProjectRepository
    {
        public EFProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Project Find(string Id)
        {
            return _dbSet.Include(x => x.Contributers).FirstOrDefault(x => x.Id == Id);
        }
    }
}
