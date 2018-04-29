using System;
using System.ComponentModel.DataAnnotations;
using Kanban.Domain.Model.Entities;
using NJsonSchema.Annotations;

namespace Kanban.Web.API.Models.Request
{
    public class CreateProjectTaskModel
    {
        [Required]
        [NotNull]
        public string Name { get; set; }

        [Required]
        [NotNull]
        public string Description { get; set; }

        [Required]
        [NotNull]
        public string Number { get; set; }

        [Required]
        public Guid ReporterId { get; set; }

        [Required]
        public Guid AssigneeId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        public ProjectTaskStatus Status { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
    }
}
