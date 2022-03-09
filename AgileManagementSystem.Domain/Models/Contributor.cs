using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Models
{
    public class Contributor : Entity
    {
        public string Email { get; private set; }

        private List<Project> _projects = new List<Project>();
        public IReadOnlyCollection<Project> Projects => _projects;
        public Contributor(string email)
        {
            Id = Guid.NewGuid().ToString();
            ValidateEmail(email);
        }

        public void SetEmail(string email)
        {
            ValidateEmail(email);
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email gerekli bir alandır.");
            }
            Email = email;
        }
    }
}
