using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
    public class ApplicationUserToRoleDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }

        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
