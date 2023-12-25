using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
