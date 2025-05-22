using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class ProductsRepositoryTesting
    {
        [Fact]
        public async Task GetAll_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Bone", Price = 10, Description = "Dog bone" },
                new Product { Id = 2, Name = "Ball", Price = 15, Description = "Toy ball" }
            };
            var mockContext = new Mock<PetsShop_DBContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            var repo = new ProductRepositories(mockContext.Object);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.Equal(products, result);
        }

        [Fact]
        public async Task GetById_ReturnsProduct_WhenExists()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Bone", Price = 10, Description = "Dog bone" };
            var products = new List<Product> { product };
            var mockContext = new Mock<PetsShop_DBContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            var repo = new ProductRepositories(mockContext.Object);

            // Act
            var result = await repo.getById(product.Id);

            // Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public async Task GetById_ReturnsNull_WhenNotExists()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Bone", Price = 10, Description = "Dog bone" }
            };
            var mockContext = new Mock<PetsShop_DBContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            var repo = new ProductRepositories(mockContext.Object);

            // Act
            var result = await repo.getById(99); // ID שלא קיים

            // Assert
            Assert.Null(result);
        }
    }
}
