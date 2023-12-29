using Demo.Core.Interfaces;
using Demo.Core.Models;
using Demo.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUserDTO>, IUserRepository
    {
        public UserRepository(DbContextClass dbContext) : base(dbContext)
        {

        }

        public async Task<ApplicationUserDTO?> AuthenticateUser(LoginViewModel model)
        {
            return _dbContext.ApplicationUsers.Include(x=>x.ApplicationUserToRoles).ThenInclude(x=>x.Role).FirstOrDefault(x => x.Email.ToLower() == model.Email.ToLower() && (!string.IsNullOrWhiteSpace(x.Password) && x.Password.ToLower() == model.Password.ToLower()));
        }
    }
}