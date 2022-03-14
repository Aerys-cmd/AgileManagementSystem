    using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Models
{
    public class ProductBacklogItemTask : Entity
    {
        public ProductBacklogItemTask(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
        public string Assignee { get; private set; }
      

        /// <summary>
        /// Todo , Done , Assigned vb.
        /// </summary>
        public TaskStatuses Status { get; set; } = TaskStatuses.Todo;
        public void SetTitle(string title)
        {
            Title = title;
        }

        public void AssignTask(string assigneeId)
        {
            Assignee = assigneeId;
            Status = TaskStatuses.InProgress;
        }

        public void CompleteTask()
        {
            Status = TaskStatuses.Done;

        }
        public void SendTaskToTest()
        {
            Status = TaskStatuses.Test;

        }
        public void SendTaskToInProgress()
        {
            Status = TaskStatuses.InProgress;

        }
    }
}
