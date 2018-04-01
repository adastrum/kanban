using Kanban.Domain.Model.Entities;
using Kanban.Infrastructure.Data;
using Xunit;

namespace Kanban.Tests
{
    public class DataTests
    {
        [Fact]
        public void Should_create_new_user()
        {
            var dbContext = new KanbanDbContext();
            var userRepository = new Repository<User>(dbContext);
            userRepository.Create(new User());
        }
    }
}
