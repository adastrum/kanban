using System.ComponentModel.DataAnnotations;
using Kanban.Domain.Model.Entities;
using NJsonSchema.Annotations;

namespace Kanban.Web.API.Models.Request
{
    public class CreateProjectModel
    {
        [Required]
        [NotNull]
        public string Name { get; set; }

        [Required]
        [NotNull]
        public string Description { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
