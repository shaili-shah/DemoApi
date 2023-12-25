using AutoMapper;
using Demo.Core.Interfaces;
using Demo.Core.Models;
using Demo.Services.Interfaces;
using Demo.ViewModels;

namespace Demo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateProduct(ProductDTO productDetails)
        {
            if (productDetails != null)
            {
                await _productRepository.Add(productDetails);

                var result = _productRepository.Save();
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _productRepository.GetById(productId);
                if (productDetails != null)
                {
                    _productRepository.Delete(productDetails);
                    var result = _productRepository.Save();
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _productRepository.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(ProductViewModel model)
        {
            if (model != null)
            {
                var product = await _productRepository.GetById(model.Id);
                if(product != null)
                {
                    product =  _mapper.Map(model,product);
                    _productRepository.Update(product);
                    var result = _productRepository.Save();
                    return result > 0;
                }
            }
            return false;
        }
    }
}
