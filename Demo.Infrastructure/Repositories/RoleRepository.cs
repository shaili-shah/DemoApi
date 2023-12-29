using Demo.Core.Interfaces;
using Demo.Core.Models;

namespace Demo.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<RoleDTO> , IRoleRepository
    {
        public RoleRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
