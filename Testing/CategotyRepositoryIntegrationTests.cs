using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace Testing
{
    public class CategotyRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly PetsShop_DBContext _dbContext;
        private readonly CategoryRepository _categoryRepository;

        public CategotyRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _categoryRepository = new CategoryRepository(_dbContext);
        }

        [Fact]
        public async Task GetAll()
        {
            var category = new Category { Name = "Dog", Products = [] };
            var categories = new List<Category> { category };
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            var result = await _categoryRepository.GetAll();

            Assert.NotNull(result);
            Assert.Equal(categories, result);
        }
    }
}
