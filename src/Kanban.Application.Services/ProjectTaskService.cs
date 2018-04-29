using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Repositories;
using Kanban.Domain.Services.Services;

namespace Kanban.Application.Services
{
    public class ProjectTaskService : ApplicationServiceBase<ProjectTask>, IProjectTaskService
    {
        public ProjectTaskService(IRepository<ProjectTask> repository) : base(repository)
        {
        }
    }
}
