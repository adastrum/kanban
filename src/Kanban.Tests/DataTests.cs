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

        [Fact]
        public void Should_seed_database()
        {
            var dbContext = new KanbanDbContext();
            var projectRepository = new Repository<Project>(dbContext);
            var project1 = new Project
            {
                Name = "Health care",
                Description =
                    "Health care or healthcare is the maintenance or improvement of health via the prevention, diagnosis, and treatment of disease, illness, injury, and other physical and mental impairments in human beings.",
                Status = ProjectStatus.Active
            };
            projectRepository.Create(project1);
            var project2 = new Project
            {
                Name = "Finance",
                Description =
                    "Finance is a field that deals with the study of investments.",
                Status = ProjectStatus.Active
            };
            projectRepository.Create(project2);
            var project3 = new Project
            {
                Name = "Entertainment",
                Description =
                    "Entertainment is a form of activity that holds the attention and interest of an audience, or gives pleasure and delight.",
                Status = ProjectStatus.Active
            };
            projectRepository.Create(project3);
        }
    }
}
