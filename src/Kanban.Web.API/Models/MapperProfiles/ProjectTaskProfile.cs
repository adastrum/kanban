using AutoMapper;
using Kanban.Domain.Model.Entities;
using Kanban.Web.API.Models.Request;
using Kanban.Web.API.Models.Response;

namespace Kanban.Web.API.Models.MapperProfiles
{
    public class ProjectTaskProfile : Profile
    {
        public ProjectTaskProfile()
        {
            CreateMap<CreateProjectTaskModel, ProjectTask>();
            CreateMap<UpdateProjectTaskModel, ProjectTask>();
            CreateMap<ProjectTask, ProjectTaskModel>();
        }
    }
}
