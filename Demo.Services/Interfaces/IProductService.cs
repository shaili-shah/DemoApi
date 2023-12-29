using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Models;
using Demo.ViewModels;

namespace Demo.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductViewModel productDetails);

        Task<IEnumerable<ProductDTO>> GetAllProducts();

        Task<ProductDTO> GetProductById(int productId);

        Task<bool> UpdateProduct(ProductViewModel productDetails);

        Task<bool> DeleteProduct(int productId);
    }
}
