using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class OrderRepositoryTesting
    {
        [Fact]
        public async Task getById()
        {
            var order = new Order { Id = 1, Date = new DateTime(2025,1,2), Sum=100, OrderItems = [] };
            var mockContext = new Mock<PetsShop_DBContext>();
            var orders = new List<Order>() { order };
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var orderRepository = new OrderRepository(mockContext.Object);

            var result = await orderRepository.getById(order.Id);

            Assert.Equal(order, result);
        }

        [Fact]
        public async Task getAll()
        {
            var order1 = new Order { Id = 1, Date = new DateTime(2025, 1, 2), Sum = 100, OrderItems = [] };
            var order2 = new Order { Id = 2, Date = new DateTime(2025, 1, 2), Sum = 200, OrderItems = [] };
            var mockContext = new Mock<PetsShop_DBContext>();
            var orders = new List<Order>() { order1, order2};
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var orderRepository = new OrderRepository(mockContext.Object);

            var result = await orderRepository.GetAll();

            Assert.Equal(orders, result);
        }

        [Fact]
        public async Task Add()
        {
            // Arrange
            var order = new Order { Id = 1, Date = new DateTime(2025, 1, 2), Sum = 100, OrderItems = [] };
            var mockContext = new Mock<PetsShop_DBContext>();
            var orders = new List<Order>();
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var orderRepository = new OrderRepository(mockContext.Object);

            // Act
            await orderRepository.Add(order);

            // Assert
            mockContext.Verify(x => x.Orders.AddAsync(order, default), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once());
        }
    }
}
