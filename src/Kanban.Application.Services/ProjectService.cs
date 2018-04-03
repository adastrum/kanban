using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Repositories;
using Kanban.Domain.Services.Services;

namespace Kanban.Application.Services
{
    public class ProjectService : ApplicationServiceBase<Project>, IProjectService
    {
        public ProjectService(IRepository<Project> repository) : base(repository)
        {
        }
    }
}
