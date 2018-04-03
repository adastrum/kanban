using Kanban.Application.Services;
using Kanban.Application.Services.Filters;
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

        [Fact]
        public void Should_create_and_read_project()
        {
            var dbContext = new KanbanDbContext();
            var projectRepository = new Repository<Project>(dbContext);
            var projectService = new ProjectService(projectRepository);
            projectService.Create(new Project { Description = "testtesttest" });
            var projects = projectService.Get(new ProjectFilter { Description = "test" });
        }
    }
}
