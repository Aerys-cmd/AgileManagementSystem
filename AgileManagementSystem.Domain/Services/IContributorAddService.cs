using AgileManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Services
{
    public interface IContributorAddService
    {

        public void AddContributor(Contributor contributor, Project project);
    }
}
