namespace Demo.Core.ViewModels
{
    public class UserToRoleViewModel
    {
        public UserToRoleViewModel() {
            Role = new RoleViewModel();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public RoleViewModel Role { get; set; }

    }
}
