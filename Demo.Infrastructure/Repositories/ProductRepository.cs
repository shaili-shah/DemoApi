using Demo.Core.Interfaces;
using Demo.Core.Models;

namespace Demo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<ProductDTO>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }

    }
}
