using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using TestProject;

namespace Testing
{
    public class OrderRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly PetsShop_DBContext _dbContext;
        private readonly OrderRepository _orderRepository;

        public OrderRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _orderRepository = new OrderRepository(_dbContext);
        }

        [Fact]
        public async Task Add_AddsOrderWithOrderItems()
        {
            // Arrange:
            var user = new User { UserName = "orderuser", Password = "123", FirstName = "Order", LastName = "Tester" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var product = new Product { Name = "Toy", Price = 50, Description = "Dog Toy", ImageURL = "img.jpg" };
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var orderItem = new OrderItem { ProductId = product.Id, Quantity = 2 };
            var order = new Order
            {
                Date = DateTime.UtcNow,
                Sum = 100,
                UserId = user.Id,
                OrderItems = new List<OrderItem> { orderItem }
            };

            // Act
            await _orderRepository.Add(order);

            // Assert
            var savedOrder = await _dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == order.Id);
            Assert.NotNull(savedOrder);
            Assert.Single(savedOrder.OrderItems);
            Assert.Equal(2, savedOrder.OrderItems.First().Quantity);
        }

        [Fact]
        public async Task GetById_ReturnsOrderWithOrderItems()
        {
            // Arrange: 
            var user = new User { UserName = "byiduser", Password = "456", FirstName = "Id", LastName = "Order" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var product = new Product { Name = "Food", Price = 30, Description = "Cat Food", ImageURL = "img2.jpg" };
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var orderItem = new OrderItem { ProductId = product.Id, Quantity = 3 };
            var order = new Order
            {
                Date = DateTime.UtcNow,
                Sum = 90,
                UserId = user.Id,
                OrderItems = new List<OrderItem> { orderItem }
            };
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _orderRepository.getById(order.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.Id, result.Id);
            Assert.Equal(1, result.OrderItems.Count);
            Assert.Equal(3, result.OrderItems.First().Quantity);
        }

        [Fact]
        public async Task GetAll_ReturnsAllOrdersWithOrderItems()
        {
            // Arrange:
            var orders = await _dbContext.Orders.ToListAsync();
            _dbContext.Orders.RemoveRange(orders);
            await _dbContext.SaveChangesAsync();

            var user = new User { UserName = "allorders", Password = "xyz", FirstName = "All", LastName = "Orders" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var product = new Product { Name = "Leash", Price = 25, Description = "Dog Leash", ImageURL = "img3.jpg" };
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var order1 = new Order
            {
                Date = DateTime.UtcNow,
                Sum = 25,
                UserId = user.Id,
                OrderItems = new List<OrderItem> { new OrderItem { ProductId = product.Id, Quantity = 1 } }
            };
            var order2 = new Order
            {
                Date = DateTime.UtcNow,
                Sum = 50,
                UserId = user.Id,
                OrderItems = new List<OrderItem> { new OrderItem { ProductId = product.Id, Quantity = 2 } }
            };
            await _dbContext.Orders.AddRangeAsync(order1, order2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _orderRepository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
            Assert.Contains(result, o => o.Sum == 25);
            Assert.Contains(result, o => o.Sum == 50);
            Assert.All(result, o => Assert.NotNull(o.OrderItems));
        }
    }
}