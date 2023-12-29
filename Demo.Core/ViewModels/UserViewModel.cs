using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public string? Password { get; set; }

        public List<int> RoleIds { get; set; }

    }
}
