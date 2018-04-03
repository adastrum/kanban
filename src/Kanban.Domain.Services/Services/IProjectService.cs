using Kanban.Domain.Model.Entities;

namespace Kanban.Domain.Services.Services
{
    public interface IProjectService : ICrudService<Project>, IFilterable<Project>
    {
    }
}
