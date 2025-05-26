using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class CategotyRepositoryTesting
    {
        [Fact]
        public async Task GetAll_ReturnsAllCategoriesWithProducts()
        {
            // Arrange
            var cat1 = new CategoryDto
            {
                Id = 1,
                Name = "Toys",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Bone" }
                }
            };
            var cat2 = new CategoryDto
            {
                Id = 2,
                Name = "Food",
                Products = new List<Product>
                {
                    new Product { Id = 2, Name = "Dog food" }
                }
            };
            var categories = new List<CategoryDto> { cat1, cat2 };

            var mockContext = new Mock<PetsShop_DBContext>();
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);

            var repo = new CategoryRepository(mockContext.Object);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.Equal(categories, result);
            Assert.All(result, c => Assert.True(c.Products.Count > 0));
        }

    }
}
