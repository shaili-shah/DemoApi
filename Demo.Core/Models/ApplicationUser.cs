namespace Demo.Core.Models
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public string? Password { get; set; }

        public List<ApplicationUserToRoleDTO> ApplicationUserToRoles { get; set; } = new List<ApplicationUserToRoleDTO>();


    }
}