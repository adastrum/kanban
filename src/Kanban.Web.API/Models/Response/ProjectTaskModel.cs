using System;
using Kanban.Domain.Model.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Kanban.Web.API.Models.Response
{
    public class ProjectTaskModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public Guid ReporterId { get; set; }

        public Guid AssigneeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectTaskStatus Status { get; set; }

        public Guid ProjectId { get; set; }
    }
}
