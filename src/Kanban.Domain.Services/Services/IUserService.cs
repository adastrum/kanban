using Kanban.Domain.Model.Entities;

namespace Kanban.Domain.Services.Services
{
    public interface IUserService : ICrudService<User>, IFilterable<User>
    {
    }
}
