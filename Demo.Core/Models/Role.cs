using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Models
{
    public class RoleDTO
    {
        [ForeignKey("ApplicationUserDTO")]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ApplicationUserToRoleDTO> ApplicationUserToRoles { get; set; } = new List<ApplicationUserToRoleDTO>();
    }
}
