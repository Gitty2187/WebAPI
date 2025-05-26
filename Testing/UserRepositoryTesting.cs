using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using Xunit;
using AutoMapper;
using static DTOs.UserDTO;

namespace Testing
{
    public class UserRepositoryTesting
    {
        private Mock<IMapper> GetMapperMock()
        {
            var mapperMock = new Mock<IMapper>();
            
            mapperMock.Setup(m => m.Map<UserRegister, User>(It.IsAny<UserRegister>()))
                      .Returns((UserRegister ur) => new User
                      {
                          UserName = ur.UserName,
                          Password = ur.Password,
                          FirstName = ur.FirstName,
                          LastName = ur.LastName
                      });
            return mapperMock;
        }

        [Fact]
        public async Task GetUsers()
        {
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer" };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var mapperMock = GetMapperMock();

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.GetUsers();

            Assert.Equal(users, result);
        }

        [Fact]
        public async Task GetById()
        {
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer", Id = 1 };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var mapperMock = GetMapperMock();

            var userRepository = new UserRepository(mockContext.Object);
                
            var result = await userRepository.getById(user.Id);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Login()
        {
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer", Id = 1 };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var mapperMock = GetMapperMock();

            var userRepository = new UserRepository(mockContext.Object);

            UserLogin userLogin = new UserLogin(user.UserName,user.Password);
            var result = await userRepository.login(userLogin);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Register_AddsUserToDatabase()
        {
            // Arrange
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer" };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

           
            var userRepository = new UserRepository(mockContext.Object);

            // Act
            await userRepository.register(user);

            // Assert
            mockContext.Verify(x => x.Users.AddAsync(user, default), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task Update()
        {
            var user = new User { Id = 1, FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer" };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User> { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var mapperMock = GetMapperMock();

            var userRepository = new UserRepository(mockContext.Object);

            await userRepository.update(user, user.Id);

            mockContext.Verify(x => x.Users.Update(user), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once());
        }
    }
}