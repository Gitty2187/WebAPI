using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using TestProject;

namespace Testing
{
    public class ProductRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly PetsShop_DBContext _dbContext;
        private readonly ProductRepositories _productRepositories;

        public ProductRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _productRepositories = new ProductRepositories(_dbContext);
        }

        [Fact]
        public async Task GetAll_ReturnsAllProducts()
        {
            // Clean up the products table to ensure test isolation
            var productsToRemove = await _dbContext.Products.ToListAsync();
            _dbContext.Products.RemoveRange(productsToRemove);
            await _dbContext.SaveChangesAsync();

            // Add test data
            var product1 = new Product { Name = "Toy", Price = 50, Description = "Dog Toy", ImageURL = "img1.jpg" };
            var product2 = new Product { Name = "Food", Price = 100, Description = "Cat Food", ImageURL = "img2.jpg" };
            await _dbContext.Products.AddRangeAsync(product1, product2);
            await _dbContext.SaveChangesAsync();

            var products = await _productRepositories.GetAll();

            Assert.NotNull(products);
            Assert.True(products.Count >= 2);
            Assert.Contains(products, p => p.Name == "Toy");
            Assert.Contains(products, p => p.Name == "Food");
        }

        [Fact]
        public async Task GetById_ReturnsCorrectProduct()
        {
            // Add test product
            var product = new Product { Name = "Bone", Price = 20, Description = "Chew Bone", ImageURL = "bone.jpg" };
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var result = await _productRepositories.getById(product.Id);

            Assert.NotNull(result);
            Assert.Equal("Bone", result.Name);
            Assert.Equal(20, result.Price);
            Assert.Equal("Chew Bone", result.Description);
        }
    }
}