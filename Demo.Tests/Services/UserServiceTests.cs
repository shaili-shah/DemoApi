using AutoMapper;
using Demo.Core.Interfaces;
using Demo.Core.Models;
using Demo.Core.ViewModels;
using Demo.Services;
using Moq;

namespace Demo.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public async Task CreateUser_ValidModel_ReturnsTrue()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>(MockBehavior.Strict);
            var mapperMock = new Mock<IMapper>(MockBehavior.Strict);

            var model = new UserViewModel()
            {
                Email = "user1@gmail.com",
                Firstname = "user",
                Lastname = "user",
                Password = "user123456",
                RoleIds = new List<int>() { 1 }
            };
            ApplicationUserDTO user = new()
            {
                Email = "user1@gmail.com",
                Firstname = "user",
                Lastname = "user",
                Password = "user123456",
            };
            mapperMock.Setup(x=>x.Map<ApplicationUserDTO>(model)).Returns(user);
            userRepoMock.Setup(x =>x.Add(It.IsAny<ApplicationUserDTO>())).Returns(Task.CompletedTask);
            userRepoMock.Setup(x => x.Save()).Returns(1);
            var userService = new UserService(userRepoMock.Object,mapperMock.Object);

            // Act
            var result = await userService.CreateUser(model);
            Assert.That(result, Is.True);
            userRepoMock.Verify(x => x.Add(It.IsAny<ApplicationUserDTO>()), Times.Once());
            userRepoMock.Verify(x=> x.Save(),Times.AtLeast(2));
        } 
    }
}