using System;
using Kanban.Domain.Model.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Kanban.Web.API.Models.Response
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectStatus Status { get; set; }
    }
}
