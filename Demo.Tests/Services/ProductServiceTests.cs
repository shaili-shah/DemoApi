using Demo.Core.Models;
using Demo.Services;
using Moq;
using Demo.Core.Interfaces;
using AutoMapper;
using Demo.ViewModels;

namespace Demo.Tests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public async Task GetProductList_Returns_ProductList()
        {
            // Arrange
            var productRepoMock = new Mock<IProductRepository>(MockBehavior.Strict);
            productRepoMock.Setup(x => x.GetAll()).ReturnsAsync(GetAllProducts());
            var mapper = new Mock<IMapper>(MockBehavior.Strict);
            var productService = new ProductService(productRepoMock.Object, mapper.Object);

            // Act
            var result = await productService.GetAllProducts();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            productRepoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public async Task GetProductById_Returns_Product()
        {
            // Arrange
            var productRepoMock = new Mock<IProductRepository>(MockBehavior.Strict);
            productRepoMock.Setup(x => x.GetById(1)).ReturnsAsync(new ProductDTO());
            var mapper = new Mock<IMapper>(MockBehavior.Strict);
            var productService = new ProductService(productRepoMock.Object, mapper.Object);
            var productId = 1;
            var expectedDTO = new ProductDTO
            {
                Id = productId,
                ProductName = "Test",
                ProductDescription = "Test",
                ProductPrice = 999
            };

            productRepoMock.Setup(x => x.GetById(productId)).ReturnsAsync(expectedDTO);

            // Act
            var result = await productService.GetProductById(productId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(expectedDTO));

            productRepoMock.Verify(x => x.GetById(productId), Times.Once);
        }

        [Test]
        public async Task CreateProduct_ValidModel_ReturnsTrue()
        {
            // Arrange
            var productRepoMock = new Mock<IProductRepository>(MockBehavior.Strict);
            var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

            var productService = new ProductService(productRepoMock.Object, mapperMock.Object);

            var model = new ProductViewModel
            {
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };
            var productDTO = MakeProductEntity();

            mapperMock.Setup(m => m.Map<ProductDTO>(model)).Returns(MakeProductEntity());

            productRepoMock.Setup(repo => repo.Add(It.IsAny<ProductDTO>())).Returns(Task.CompletedTask);
            productRepoMock.Setup(repo => repo.Save()).Returns(1);

            // Act
            var result = await productService.CreateProduct(model);

            // Assert
            Assert.IsTrue(result);

            // Verify that add and save were called once
            productRepoMock.Verify(repo => repo.Add(It.IsAny<ProductDTO>()), Times.Once);
            productRepoMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public async Task UpdateProduct_ValidModel_ReturnsTrue()
        {
            // Arrange
            var productId = 1;
            var productRepoMock = new Mock<IProductRepository>(MockBehavior.Strict);
            var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
            var model = new ProductViewModel
            {
                Id = productId,
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };

            ProductDTO productDTO = new ProductDTO()
            {
                Id = productId,
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };
            productRepoMock.Setup(x => x.GetById(productId)).ReturnsAsync(productDTO);
            mapperMock.Setup(x => x.Map(model, productDTO)).Returns(new ProductDTO());
            productRepoMock.Setup(x => x.Update(It.IsAny<ProductDTO>()));
            productRepoMock.Setup(x => x.Save()).Returns(1);
            var productService = new ProductService(productRepoMock.Object, mapperMock.Object);

            // act
            var result = await productService.UpdateProduct(model);

            // assert
            productRepoMock.Verify(x => x.GetById(productId), Times.Once);
            mapperMock.Verify(m => m.Map(model, productDTO), Times.Once);
            productRepoMock.Verify(x => x.Update(It.IsAny<ProductDTO>()), Times.Once);
            productRepoMock.Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public async Task DeleteProduct_ValidModel_ReturnsTrue()
        {
            // Arrange
            var productId = 1;
            var productRepoMock = new Mock<IProductRepository>(MockBehavior.Strict);
            var mapperMock = new Mock<IMapper>(MockBehavior.Strict);
            ProductDTO productDTO = new ProductDTO()
            {
                Id = productId,
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };
            productRepoMock.Setup(x => x.GetById(productId)).ReturnsAsync(productDTO);
            productRepoMock.Setup(x => x.Delete(It.IsAny<ProductDTO>()));
            productRepoMock.Setup(x => x.Save()).Returns(1);

            var productService = new ProductService(productRepoMock.Object, mapperMock.Object);

            // act
            var result = await productService.DeleteProduct(productId);

            // assert
            Assert.That(result, Is.True);

        }


        private static ProductDTO MakeProductEntity()
        {
            return new ProductDTO()
            {
                ProductName = "Test_Product",
                ProductDescription = "description",
                ProductPrice = 999
            };
        }

        private static List<ProductDTO> GetAllProducts()
        {
            return new List<ProductDTO> {
                new ProductDTO() {Id=1,ProductName = "h1",ProductDescription="h1",ProductPrice=1000 },
                new ProductDTO() {Id=2,ProductName = "h2",ProductDescription="h2",ProductPrice=1000 }
            };
        }

    }
}