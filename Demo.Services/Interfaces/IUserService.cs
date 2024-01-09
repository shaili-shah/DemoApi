using Demo.Core.ViewModels;

namespace Demo.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserViewModel user);
        Task<UserWithRolesViewModel?> AuthenticateUser(LoginViewModel model);
        Task<bool> DeleteUser(int id);
        Task<bool> AssignRole(int userId, List<int> roleIds);
    }
}