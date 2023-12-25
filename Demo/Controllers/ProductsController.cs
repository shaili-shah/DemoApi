﻿using Microsoft.AspNetCore.Mvc;
using Demo.Core.Models;
using Demo.Services.Interfaces;
using AutoMapper;
using Demo.ViewModels;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productDetailsList = await _productService.GetAllProducts();
            return HandleResponse(productDetailsList);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var productDetails = await _productService.GetProductById(productId);

            return productDetails != null ? HandleResponse(productDetails) : NotFound();
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productDetails)
        {
            var model = _mapper.Map<ProductDTO>(productDetails);
            var isProductCreated = await _productService.CreateProduct(model);
            return isProductCreated ? HandleResponse(isProductCreated) : BadRequest();
        }

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductViewModel productDetails)
        {
            if (productDetails != null)
            {
                var isProductCreated = await _productService.UpdateProduct(productDetails);
                return isProductCreated ? HandleResponse(isProductCreated) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isProductCreated = await _productService.DeleteProduct(productId);
            return isProductCreated ? HandleResponse(isProductCreated) : BadRequest();
        }
    }
}