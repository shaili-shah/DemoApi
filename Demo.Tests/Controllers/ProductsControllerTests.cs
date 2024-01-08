using AutoMapper;
using Demo.Controllers;
using Demo.Core.Models;
using Demo.Services.Interfaces;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Demo.Tests.Controllers
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public async Task GetProductList_Returns_OKResultWithProductDetailsList()
        {
            // Arrange
            var expectedProductList = new List<ProductDTO>()
            {
                new ProductDTO(){Id = 1,ProductName = "p1",ProductDescription = "desc"},
                new ProductDTO(){Id = 2,ProductName = "p2",ProductDescription = "desc"}
            };
            var (controller, productServiceMock, _) = MockProductController();
            productServiceMock.Setup(x => x.GetAllProducts()).ReturnsAsync(expectedProductList);

            // Act
            var result = await controller.GetProductList();

            // Assert
            dynamic okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);
            var responseProductDetailsList = okResult.Value.Data as List<ProductDTO>;
            Assert.NotNull(responseProductDetailsList);
            CollectionAssert.AreEqual(expectedProductList, responseProductDetailsList);

            productServiceMock.Verify(x => x.GetAllProducts(), Times.Once());
        }

        [Test]
        public async Task GetProductById_ExistingProduct_ReturnsOkResult()
        {
            // Arrange
            var productId = 1;
            var expectedProductList = new ProductDTO
            {
                Id = productId,
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };

            var (controller, productServiceMock, _) = MockProductController();
            productServiceMock.Setup(service => service.GetProductById(productId)).ReturnsAsync(expectedProductList);

            // Act
            var result = await controller.GetProductById(productId);

            // Assert
            dynamic okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var responseProductDetails = okResult.Value.Data as ProductDTO;
            Assert.NotNull(responseProductDetails);
            Assert.That(responseProductDetails.Id, Is.EqualTo(expectedProductList.Id));
            Assert.That(responseProductDetails.ProductName, Is.EqualTo(expectedProductList.ProductName));

            productServiceMock.Verify(service => service.GetProductById(productId), Times.Once);
        }

        [Test]
        public async Task CreateProduct_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var model = new ProductViewModel
            {
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };

            var (controller, productServiceMock, _) = MockProductController();
            productServiceMock.Setup(service => service.CreateProduct(model)).ReturnsAsync(true);

            // Act
            var result = await controller.CreateProduct(model);

            // Assert
            dynamic okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var response = okResult.Value.Data as bool?;
            Assert.NotNull(response);
            Assert.True(response.Value);

            productServiceMock.Verify(service => service.CreateProduct(model), Times.Once);
        }

        [Test]
        public async Task UpdateProduct_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var model = new ProductViewModel
            {
                Id = 1,
                ProductName = "Updated_Product",
                ProductDescription = "updated description",
                ProductPrice = 999
            };

            var (controller, productServiceMock, _) = MockProductController();
            productServiceMock.Setup(service => service.UpdateProduct(model)).ReturnsAsync(true);

            // Act
            var result = await controller.UpdateProduct(model);

            // Assert
            dynamic okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var response = okResult.Value.Data as bool?;
            Assert.NotNull(response);
            Assert.True(response.Value);

            productServiceMock.Verify(service => service.UpdateProduct(model), Times.Once);
        }

        [Test]
        public async Task DeleteProduct_ValidProductId_ReturnsOkResult()
        {
            // Arrange
            var productId = 1;

            var (controller, productServiceMock, _) = MockProductController();
            productServiceMock.Setup(service => service.DeleteProduct(productId)).ReturnsAsync(true);
           
            // Act
            var result = await controller.DeleteProduct(productId);

            // Assert
            dynamic okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var response = okResult.Value.Data as bool?;
            Assert.NotNull(response);
            Assert.True(response.Value);

            productServiceMock.Verify(service => service.DeleteProduct(productId), Times.Once);
        }

        private  static (ProductsController,Mock<IProductService>,Mock<IMapper>) MockProductController()
        {
            var mapper = new Mock<IMapper>(MockBehavior.Strict);
            var productServiceMock = new Mock<IProductService>(MockBehavior.Strict);
            var controller = new ProductsController(productServiceMock.Object,mapper.Object);
            return (controller,productServiceMock,mapper);
        }

    }
}