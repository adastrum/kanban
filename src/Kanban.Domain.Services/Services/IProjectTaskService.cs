using Kanban.Domain.Model.Entities;

namespace Kanban.Domain.Services.Services
{
    public interface IProjectTaskService : ICrudService<ProjectTask>, IFilterable<ProjectTask>
    {
    }
}
