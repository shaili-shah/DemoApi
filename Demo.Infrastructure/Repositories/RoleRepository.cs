using Demo.Core.Interfaces;
using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<RoleDTO> , IRoleRepository
    {
        public RoleRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
