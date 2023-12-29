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
