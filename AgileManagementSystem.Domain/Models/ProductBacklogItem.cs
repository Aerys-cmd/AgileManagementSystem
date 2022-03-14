using AgileManagementSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Models
{
    public class ProductBacklogItem : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; private set; }
        public Project Project { get; private set; }


        private List<ProductBacklogItemTask> _tasks = new();
        public IReadOnlyCollection<ProductBacklogItemTask> Tasks => _tasks;

        public ProductBacklogItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddTask(ProductBacklogItemTask task)
        {
            if (_tasks.Any(x => x.Title == task.Title))
                throw new Exception("Aynı task tekrar eklenemez");

            _tasks.Add(task);

        }

    }
}
