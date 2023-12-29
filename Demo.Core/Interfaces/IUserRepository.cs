using Demo.Core.Models;
using Demo.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUserDTO>
    {
        Task<ApplicationUserDTO?> AuthenticateUser(LoginViewModel model);
    }
}
