using System.ComponentModel.DataAnnotations;
using NJsonSchema.Annotations;

namespace Kanban.Web.API.Models.Request
{
    public class CreateUserModel
    {
        [Required]
        [NotNull]
        public string Name { get; set; }
    }
}
