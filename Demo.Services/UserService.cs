using AutoMapper;
using Demo.Core.Interfaces;
using Demo.Core.Models;
using Demo.Core.ViewModels;
using Demo.Services.Interfaces;

namespace Demo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(UserViewModel model)
        {
            var user = _mapper.Map<ApplicationUserDTO>(model);
            if (user != null)
            {
                await _userRepository.Add(user);
                var result = _userRepository.Save();
                foreach (var roleId in model.RoleIds.Where(roleId => roleId > 0))
                {
                    var userToRole = new ApplicationUserToRoleDTO { RoleId = roleId, UserId = user.Id };
                    user.ApplicationUserToRoles.Add(userToRole);
                }
                _userRepository.Save();
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                var result = _userRepository.Save();
                return result > 0;
            }
            return false;
        }

        public async Task<bool> AssignRole(int userId,List<int> roleIds)
        {
            var user = await GetUserById(userId);
            if (user != null)
            {
                foreach (var roleId in roleIds.Where(roleId => roleId > 0))
                {
                    var userToRole = new ApplicationUserToRoleDTO { RoleId = roleId, UserId = user.Id };
                    user.ApplicationUserToRoles.Add(userToRole);
                }
                var result = _userRepository.Save();
                return result > 0;
            }
            return false;
        }

        public async Task<ApplicationUserDTO> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<UserWithRolesViewModel?> AuthenticateUser(LoginViewModel model)
        {
            var user = await _userRepository.AuthenticateUser(model);
            if (user != null)
            {
                return _mapper.Map<UserWithRolesViewModel>(user);
            }
            return null;
        }

    }
}
