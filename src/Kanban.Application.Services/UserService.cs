using Kanban.Domain.Model.Entities;
using Kanban.Domain.Services.Repositories;
using Kanban.Domain.Services.Services;

namespace Kanban.Application.Services
{
    public class UserService : ApplicationServiceBase<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
