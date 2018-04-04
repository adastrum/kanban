using AutoMapper;
using Kanban.Application.Services.Filters;
using Kanban.Domain.Model.Entities;
using Kanban.Web.Mvc.Models.Filters;

namespace Kanban.Web.Mvc.Models.MapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectFilter, ProjectFilterViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<ProjectTask, ProjectTaskViewModel>();
            CreateMap<Project, ProjectViewModel>();
        }
    }
}
