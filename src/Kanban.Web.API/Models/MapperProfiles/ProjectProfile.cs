using AutoMapper;
using Kanban.Domain.Model.Entities;
using Kanban.Web.API.Models.Request;

namespace Kanban.Web.API.Models.MapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectModel, Project>();
            CreateMap<UpdateProjectModel, Project>();
        }
    }
}
