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
    public class EFProductBacklogItemRepository : EFBaseRepository<ProductBacklogItem, AppDbContext>, IProductBacklogItemRepository
    {
        public EFProductBacklogItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
