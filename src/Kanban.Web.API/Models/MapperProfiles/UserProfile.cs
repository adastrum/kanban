﻿using AutoMapper;
using Kanban.Domain.Model.Entities;
using Kanban.Web.API.Models.Request;

namespace Kanban.Web.API.Models.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, User>();
        }
    }
}
