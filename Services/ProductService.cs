using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    class ProductService : IProductService
    {
        private readonly IProductRepositories _productRepositories;

        public ProductService(IProductRepositories productRepositories)
        {
            _productRepositories = productRepositories;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepositories.GetAll();
        }

        public async Task<Product> getById(int id)
        {
            if (id == null)
                throw new Exception("Must insert id");
            return await _productRepositories.getById(id);
        }
    }
}
