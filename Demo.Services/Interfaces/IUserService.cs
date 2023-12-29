using Demo.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserViewModel user);
        Task<UserWithRolesViewModel?> AuthenticateUser(LoginViewModel model);
    }
}
