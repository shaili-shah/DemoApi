namespace Demo.Core.ViewModels
{
    public class UserWithRolesViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public string? Password { get; set; }

        public List<UserToRoleViewModel>? UserToRoles { get; set; }

    }
}
