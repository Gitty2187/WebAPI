using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Testing
{
    public class UserRepositoryTesting
    {
        [Fact]
        public async Task GetUsers()
        {
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer" };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.GetUsers();

            Assert.Equal(users, result);
        }

        [Fact]
        public async Task GetByID()
        {
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer", Id = 1 };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.getById(user.Id);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task login()
        {
            var user = new User { FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer", Id = 1 };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.login(user.UserName, user.Password);

            Assert.Equal(user, result);
        }



        [Fact]
        public async Task Register()
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
            // Arrange
            var user = new User { Id = 1, FirstName = "Gitty", UserName = "G", Password = "123", LastName = "Foyer" };
            var mockContext = new Mock<PetsShop_DBContext>();
            var users = new List<User> { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            await userRepository.update(user);

            // Assert
            mockContext.Verify(x => x.Users.Update(user), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once());
        }
    }
}
