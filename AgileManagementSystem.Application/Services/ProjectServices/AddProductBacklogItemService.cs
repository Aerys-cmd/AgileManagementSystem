using AgileManagementSystem.Application.Dtos;
using AgileManagementSystem.Core.Application;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services.ProjectServices
{
    public class AddProductBacklogItemRequestDto
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
    public class AddProductBacklogItemResponseDto
    {
        public bool IsSucceeded { get; set; }
        public string Messages { get; set; }
    }
    public class AddProductBacklogItemService : IApplicationService<AddProductBacklogItemRequestDto, AddProductBacklogItemResponseDto>
    {
        private readonly IProjectRepository _projectRepository;
        public AddProductBacklogItemService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public AddProductBacklogItemResponseDto OnProcess(AddProductBacklogItemRequestDto request = null)
        {
            var project = _projectRepository.GetQuery().Include(x => x.ProductBacklog).FirstOrDefault(x => x.Id == request.ProjectId);


            var productBacklogItem = new ProductBacklogItem(request.Title, request.Description);

            foreach (var task in request.Tasks)
            {
                var mappedTask = new ProductBacklogItemTask(task.Title);
                productBacklogItem.AddTask(mappedTask);
            }

            project.AddProductBacklogItem(productBacklogItem);
            _projectRepository.Save();

            return new AddProductBacklogItemResponseDto
            {
                IsSucceeded = true,
                Messages = "İşlem Başarılı"
            };
        }
    }
}
