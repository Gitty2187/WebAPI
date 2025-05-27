using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using TestProject;

namespace Testing
{
    public class UserRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly PetsShop_DBContext _dbContext;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContext);
        }

        [Fact]
        public async Task Login_ReturnsUser_WhenCredentialsAreCorrect()
        {
            var user = new User { UserName = "testUser", Password = "1234", FirstName = "Test", LastName = "User" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var userLogin = new UserLogin("testUser", "1234");
            var result = await _userRepository.login(userLogin);

            Assert.NotNull(result);
            Assert.Equal("testUser", result.UserName);
        }

        [Fact]
        public async Task Register_AddsNewUserToDatabase()
        {
            var user = new User { UserName = "newUser", Password = "pass", FirstName = "New", LastName = "User" };
            await _userRepository.register(user);

            var createdUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == "newUser");
            Assert.NotNull(createdUser);
            Assert.Equal("New", createdUser.FirstName);
        }

        [Fact]
        public async Task Update_UpdatesUserDetails()
        {
            var user = new User { UserName = "updateUser", Password = "pass", FirstName = "Old", LastName = "Name" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            user.FirstName = "New";
            var updatedUser = await _userRepository.update(user, user.Id);

            Assert.Equal("New", updatedUser.FirstName);
            var userFromDb = await _dbContext.Users.FindAsync(user.Id);
            Assert.Equal("New", userFromDb.FirstName);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectUser()
        {
            var user = new User { UserName = "byIdUser", Password = "pass", FirstName = "By", LastName = "Id" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var result = await _userRepository.getById(user.Id);

            Assert.NotNull(result);
            Assert.Equal("byIdUser", result.UserName);
        }

        [Fact]
        public async Task GetUsers_ReturnsAllUsers()
        {
            // Clean up users table to avoid test pollution
            var allUsers = await _dbContext.Users.ToListAsync();
            _dbContext.Users.RemoveRange(allUsers);
            await _dbContext.SaveChangesAsync();

            var user1 = new User { UserName = "user1", Password = "p1", FirstName = "f1", LastName = "l1" };
            var user2 = new User { UserName = "user2", Password = "p2", FirstName = "f2", LastName = "l2" };
            await _dbContext.Users.AddRangeAsync(user1, user2);
            await _dbContext.SaveChangesAsync();

            var users = await _userRepository.GetUsers();

            Assert.NotNull(users);
            Assert.True(users.Count >= 2);
            Assert.Contains(users, u => u.UserName == "user1");
            Assert.Contains(users, u => u.UserName == "user2");
        }
    }
}